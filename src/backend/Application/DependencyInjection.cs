using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var domainTypes = new HashSet<Type>
        {
            typeof(ICommandHandler<>),
            typeof(ICommandHandler<,>),
            typeof(IQueryHandler<,>)
        };

        var handlers = typeof(ICommand).Assembly.GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.GetTypeInfo().ImplementedInterfaces.Intersect(domainTypes).Any());

        foreach (var handler in handlers)
        {
            services.AddScoped(handler);
        }

        return services;
    }
}