using Infrastructure.Persistence;
using Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Hosting;
using NLog.Extensions.Logging;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        return builder.AddPersistence(configuration)
            .AddLogging(configuration)
            .Services;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<DataContext>(
            options => options
                .UseInMemoryDatabase("plumsail-test-task"));
        // .UseNpgsql(connectionString, b =>
        // {
        //     b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        // })
        // .UseSnakeCaseNamingConvention());

        builder.Services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());

        return builder;
    }

    private static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
        
        var loggerConfigurationSection = configuration.GetSection("NLog");
        var loggerConfiguration = new NLogLoggingConfiguration(loggerConfigurationSection);
        LogManager.Configuration = loggerConfiguration;
        
        return builder;
    }
}