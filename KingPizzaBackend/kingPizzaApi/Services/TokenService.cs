using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using kingPizzaApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace KingPizzaApi.Services;

public class TokenService
{
    public string GenerateToken(Cliente cliente)
    {
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new Exception("JWT_KEY missing in .env");
        var key = Encoding.ASCII.GetBytes(jwtKey);

        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, cliente.Id.ToString()),
                new Claim(ClaimTypes.Email, cliente.Email),
                new Claim(ClaimTypes.Role, cliente.IsAdmin ? "Admin" : "Cliente")
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);

        return tokenHandler.WriteToken(token);
    }
}