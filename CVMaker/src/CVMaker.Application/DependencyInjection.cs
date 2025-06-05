using System.Reflection;
using System.Xml.Schema;
using CVMaker.Application.Abstractions.Behaviors;
using CVMaker.Application.Abstractions.Extensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CVMaker.Application
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

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

            return services;
        }
    }
}
