using slavagmBackend.Core.Services;
using slavagmBackend.Services.Helpers;

namespace slavagmBackend.Services.Services;

public class AuthService : IAuthService
{
    public async Task<string> Login(string password)
    {
        if (string.IsNullOrEmpty(password) || password != AuthOptions.AdminPassword)
        {
            throw new UnauthorizedAccessException("Invalid password");
        }

        return TokenHelper.CreateToken();
    }
}