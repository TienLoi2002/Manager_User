using AutoMapper;
using Manager_User_API.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class TokenHelper
{
    private readonly IConfiguration _configuration;
    private readonly IUserIdClaimTypeAndCliamValueRepository _userClaimRepository;
    private readonly IMapper _mapper;

    public TokenHelper(IConfiguration configuration, IUserIdClaimTypeAndCliamValueRepository userClaimRepository, IMapper mapper)
    {
        _configuration = configuration;
        _userClaimRepository = userClaimRepository;
        _mapper = mapper;
    }

    public async Task<string> GenerateTokenAsync(string username)
    {

        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
        var tokenHandler = new JwtSecurityTokenHandler();

        var userClaimsDTO = await _userClaimRepository.GetUserClaimsAsync(username);
        var claims = userClaimsDTO.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList();
        claims.Add(new Claim(ClaimTypes.Name, username));

        var claimsIdentity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryMinutes"])),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
