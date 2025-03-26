using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Abstractions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services
            .AddMemoryCache(x =>
            {
                x.ExpirationScanFrequency = TimeSpan.FromMinutes(5);
                x.SizeLimit = 300;
            })
            .AddValidatorsFromAssembly(assembly)
            .AddFluentValidationAutoValidation()
            .AddHandlersFromAssembly(assembly);
    }

    private static IServiceCollection AddHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var domainTypes = new HashSet<Type>
        {
            typeof(IBaseCommandHandler),
            typeof(IQueryHandler)
        };

        var handlers = assembly.GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.GetTypeInfo().ImplementedInterfaces.Intersect(domainTypes).Any());

        foreach (var handler in handlers)
        {
            services.AddScoped(handler);
        }
        
        return services;
    }
}