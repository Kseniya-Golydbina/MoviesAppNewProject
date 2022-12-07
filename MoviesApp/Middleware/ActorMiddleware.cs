using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware;

public class ActorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ActorMiddleware> _logger;

    public ActorMiddleware(RequestDelegate next, ILogger<ActorMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.GetDisplayUrl().Contains("Actor"))
        {
            _logger.LogInformation($"{httpContext.Request.Method}" +
                                   $"{httpContext.Request.Path}" +
                                   $"{httpContext.Request.Protocol}" +
                                   $"{httpContext.Request.ContentType}" +
                                   $"{httpContext.Request.QueryString.Value}");
        }

        return _next(httpContext);
    }
}

public static class CustomMiddlewareForActorsExtension
{
    public static IApplicationBuilder UseActorCustom(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActorMiddleware>();
    }
}
