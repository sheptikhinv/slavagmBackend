namespace slavagmBackend.Services.Exceptions;

public abstract class ServiceException(string message) : Exception(message)
{
    public abstract int StatusCode { get; }
}