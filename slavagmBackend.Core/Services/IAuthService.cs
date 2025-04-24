namespace slavagmBackend.Core.Services;

public interface IAuthService
{
    public Task<string> Login(string password);
}