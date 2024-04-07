using System.Net;
using System.Text.Json;
using ClinicManager.Api.Abstractions;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Api.Middlewares;

/// <summary>
/// Represents a global exception handler.
/// </summary>
public class ExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var apiErrorResponse = new ApiErrorResponse(new[] { new Error("Server.UnknownError", exception.Message)});
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(json);
        }
    }
}