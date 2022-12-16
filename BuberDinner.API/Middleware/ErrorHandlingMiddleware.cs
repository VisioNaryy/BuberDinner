using System.Net;
using System.Text.Json;

namespace BuberDinner.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorCode = HttpStatusCode.InternalServerError;
        
        context.Response.StatusCode = (int)errorCode;
        context.Response.Headers.Add("content-type", "application/json");

        var json = JsonSerializer.Serialize(new {ErrorCode = errorCode, exception.Message});

        await context.Response.WriteAsync(json);
    }
}