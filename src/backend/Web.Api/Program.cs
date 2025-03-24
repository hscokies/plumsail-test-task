using Application;
using Infrastructure;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddEndpoints()
    .AddPresentation();

var app = builder.Build();
app.MapEndpoints();
// Should have probably added health checks
app.MapGet("/api/ping", (c) => c.Response.WriteAsync("Ok")).WithOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(c =>
    {
        c.Path = "/api/swagger";
    });
    // app.UseSwagger(options => options.RouteTemplate = "api/swagger/{documentname}/swagger.json");
    // app.UseSwaggerUI(c =>
    // {
    //     c.RoutePrefix = "api/swagger";
    //     c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Forms API");
    // });
    app.ApplyMigrations();
}

app.UseHttpsRedirection();


app.Run();