using System;
using Application;
using Infrastructure;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Logging;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup()
    .LoadConfigurationFromSection(builder.Configuration.GetSection("NLOG"))
    .GetCurrentClassLogger();

try
{
    builder.AddInfrastructure(builder.Configuration)
        .AddApplication()
        .AddEndpoints()
        .AddPresentation();

    var app = builder.Build();
    app.MapEndpoints();

    // Should have probably added health checks
    app.MapGet("/api/ping", (c) => c.Response.WriteAsync("Ok")).WithOpenApi();

    app.UseExceptionHandler();
    app.UseLoggingMiddleware();

    if (!app.Environment.IsProduction())
    {
        app.UseOpenApi(c => { c.Path = "/api/swagger/{documentName}/swagger.json"; });
        app.UseSwaggerUi(c =>
        {
            c.DocumentPath = "/api/swagger/{documentName}/swagger.json";
            c.Path = "/api/swagger";
        });

        // https://devblogs.microsoft.com/dotnet/introducing-devops-friendly-ef-core-migration-bundles/
        app.ApplyMigrations();
    }

    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Exception occured during startup {message}.", ex.Message);
}
finally
{
    LogManager.Shutdown();
}