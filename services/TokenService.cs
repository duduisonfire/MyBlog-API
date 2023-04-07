using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyBlogAPI.Models;
namespace MyBlogAPI.Services;

public static class TokenService
{
    public static string GenerateToken(Users user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        string? tokenSecret = Environment.GetEnvironmentVariable("JwtSecret");
        byte[] key = Encoding.ASCII.GetBytes(tokenSecret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject =
                new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, user.User!),
                new Claim(ClaimTypes.Role, user.UserLevel.ToString()!),
                new Claim(ClaimTypes.Name, user.UserFullName!),
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
