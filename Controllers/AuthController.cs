using Manager_User_API.DTO;
using Manager_User_API.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly TokenHelper _tokenHelper;

    public AuthController(IUserService userService, TokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    [HttpPost("login")]
    [AllowAnonymous]

    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        var user = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        var token = await _tokenHelper.GenerateTokenAsync(user.Username);
        var refreshToken = _tokenHelper.GenerateRefreshToken();

        await _userService.SaveRefreshTokenAsync(user.Username, refreshToken.Token);

        return Ok(new { token, refreshToken = refreshToken.Token });
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]

    public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
    {
        var response = await _userService.RefreshTokenAsync(request.Token, request.RefreshToken);
        if (response == null)
        {
            return Unauthorized();
        }

        return Ok(response);
    }

    [HttpPost("register")]
    [AllowAnonymous]

    public async Task<IActionResult> Register(RegisterDTO registerDto)
    {
        await _userService.RegisterAsync(registerDto);
        return Ok();
    }
}
