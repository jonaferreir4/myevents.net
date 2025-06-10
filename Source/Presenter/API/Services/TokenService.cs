using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using API.Helpers;
using Application.UseCases.User.Login;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService(RSA privateKey)
{
    private readonly RSA _privateKey = privateKey;

    internal string GenerateJwtToken(LoginUserResponse user)
    {
        var securityKey = new RsaSecurityKey(_privateKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: AuthOptionsHelper.Issuer,
            audience: AuthOptionsHelper.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}