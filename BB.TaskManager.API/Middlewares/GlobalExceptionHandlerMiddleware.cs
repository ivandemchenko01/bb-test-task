using System.Net;
using Newtonsoft.Json;

namespace BB.TaskManager.API.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorMessage = "An unexpected error occurred.";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = errorMessage + ex.Message }));
        }
    }
}