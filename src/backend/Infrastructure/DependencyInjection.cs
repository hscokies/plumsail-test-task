using Infrastructure.Persistence;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Extensions.Logging;
using NLog.Targets;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddPersistence(configuration)
            .AddLogging();
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DataContext>(
            options => options
#if DEBUG
                .UseInMemoryDatabase("plumsail-test-task"));
#else
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
#endif

        services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());

        return services;
    }

    private static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
    {
        var loggerConfigurationSection = configuration.GetSection("NLog");
        var loggerConfiguration = new NLogLoggingConfiguration(loggerConfigurationSection);
        var consoleTarget = new ColoredConsoleTarget
        {
            Name = "c",
            Layout = "${level:uppercase=true}|${longdate}|${logger}\n${message}"
        };

        loggerConfiguration.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget);
        LogManager.Configuration = loggerConfiguration;

        return services;
    }
}