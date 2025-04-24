using slavagmBackend.Services.Exceptions;

namespace slavagmBackend.API.Middlewares;

public class ExceptionsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionsMiddleware> _logger;

    public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ServiceException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = ex.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = "Internal Server Error. GG WP, request bub fix"
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }

}