using System;
using Application;
using Infrastructure;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

    app.UseLoggingMiddleware();

    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
        app.UseSwaggerUi(c => { c.Path = "/api/swagger"; });
        app.ApplyMigrations();
    }

    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Exception occured during startup.");
}
finally
{
    LogManager.Shutdown();
}