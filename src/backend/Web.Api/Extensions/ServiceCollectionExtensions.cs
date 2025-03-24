using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Web.Api.Enpoints;
using Web.Api.Infrastructure;

namespace Web.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var serviceDescriptors = typeof(IEndpoint).Assembly.GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type));

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}