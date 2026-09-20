using Microsoft.AspNetCore.Mvc;
using UnitConversion.Api.Exceptions;
namespace UnitConversion.Api.Middleware;
public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try { await next(context); }
        catch (UnsupportedConversionException ex)
        {
            logger.LogInformation(ex, "Unsupported conversion requested");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Unsupported conversion",
                Detail = ex.Message
            });
        }
    }
}
