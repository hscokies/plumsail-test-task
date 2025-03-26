using Microsoft.AspNetCore.Builder;
using Web.Api.Middleware;

namespace Web.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseLoggingMiddleware(this WebApplication app)
    {
        app.UseMiddleware<LoggingMiddleware>();
        return app;
    }
}