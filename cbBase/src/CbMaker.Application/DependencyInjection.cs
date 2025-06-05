using System.Reflection;
using CbMaker.Application.Abstractions.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CbMaker.Application
{
    public static class DependencyInjection
    {
      public static IServiceCollection AddApplicationServices(this IServiceCollection services)
{
    services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>)); 
    });

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

    // services.RegisterServicesFromAttributes(Assembly.GetExecutingAssembly()); // Quitar si no existe

    return services;
}

        }
    }

