namespace slavagmBackend.Services.Exceptions;

public class NotFoundException(string message) : ServiceException(message)
{
    public override int StatusCode => 404;
}