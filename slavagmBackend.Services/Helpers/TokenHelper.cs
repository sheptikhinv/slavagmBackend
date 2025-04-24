using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace slavagmBackend.Services.Helpers;

public static class TokenHelper
{
    public static string CreateToken()
    {
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.Add(AuthOptions.TokenLifetime),
            signingCredentials: new SigningCredentials(AuthOptions.SymmetricSecurityKey,
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}