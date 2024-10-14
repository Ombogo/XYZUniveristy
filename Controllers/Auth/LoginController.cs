using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XYZUniversityPaymentsAPI.Models;

namespace XYZUniversityPaymentsAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login login)
    {
        // user validation logic
        if (login.Username == "admin" && login.Password == "password")
        {
            var securityToken = await GenerateJwtToken(login.Username);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                expires_in = Math.Truncate((securityToken.ValidTo - DateTime.UtcNow).TotalSeconds)
            });
        }

        return Unauthorized(new { message = "Invalid credentials" });
    }

    private async Task<SecurityToken> GenerateJwtToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        //Generate token that is valid for 1 hour
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", username) }),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return token;
    }
}