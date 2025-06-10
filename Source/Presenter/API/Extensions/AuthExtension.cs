using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API.Helpers;
using API.Services;

namespace API.Extensions;

internal static class AuthExtension
{
    internal static void AddJwtAuthentication(this IServiceCollection self)
    {
        self.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, 
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = AuthOptionsHelper.Issuer,
                    ValidAudience = AuthOptionsHelper.Audience,

                    IssuerSigningKey = new RsaSecurityKey(RSAKeyHelper.PublicKey)
                };
            });

        self.AddSingleton<TokenService>(sp =>
        {
        var privateKey = RSAKeyHelper.PrivateKey;
        return new TokenService(privateKey);
        });
        self.AddAuthorization();
    }
}
