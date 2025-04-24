namespace slavagmBackend.Services.Exceptions;

public class UnauthorizedException(string message) : ServiceException(message)
{
    public override int StatusCode => 402;
}