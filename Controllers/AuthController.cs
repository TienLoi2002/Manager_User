using Manager_User_API.DTO;
using Manager_User_API.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[AllowAnonymous]
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
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        var user = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        var token = _tokenHelper.GenerateTokenAsync(user.Username);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO registerDto)
    {
        await _userService.RegisterAsync(registerDto);
        return Ok();
    }
}

