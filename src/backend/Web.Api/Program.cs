using Application;
using Infrastructure;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddEndpoints()
    .AddPresentation();

var app = builder.Build();

// Should have probably added health checks
app.Map("/ping", innerApp => innerApp.Run(async innerContext => await innerContext.Response.WriteAsync("Ok")));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.RouteTemplate = "api/swagger/{documentname}/swagger.json");
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "api/swagger";
        c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Forms API");
    });
    app.ApplyMigrations();
}

app.UseHttpsRedirection();


app.Run();