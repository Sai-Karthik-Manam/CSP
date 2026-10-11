using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CSP.API.Services.Interfaces;

namespace CSP.API.Services.Implementations;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(int userId,string userName,string citizenId,int role)
    {
        var key = _configuration["Jwt:Key"];

        if (string.IsNullOrWhiteSpace(key) ||
            Encoding.UTF8.GetByteCount(key) < 32)
        {
            throw new InvalidOperationException(
                "JWT signing key must be configured with at least 32 bytes.");
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
            new Claim(ClaimTypes.Name,userName),
            new Claim("citizenId",citizenId),
            new Claim(ClaimTypes.Role,role.ToString())
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(
                    _configuration["Jwt:ExpiryMinutes"] ?? "30")),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}