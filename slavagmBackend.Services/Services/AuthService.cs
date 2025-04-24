using slavagmBackend.Core.Services;
using slavagmBackend.Services.Exceptions;
using slavagmBackend.Services.Helpers;

namespace slavagmBackend.Services.Services;

public class AuthService : IAuthService
{
    public async Task<string> Login(string password)
    {
        if (string.IsNullOrEmpty(password) || password != AuthOptions.AdminPassword)
        {
            throw new UnauthorizedException("Invalid password");
        }

        return TokenHelper.CreateToken();
    }
}