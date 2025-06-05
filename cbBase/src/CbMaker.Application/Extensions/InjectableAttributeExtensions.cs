using CbMaker.Application.Common.Decorators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace CVMaker.Application.Abstractions.Extensions
{
    public static class InjectableAttributeExtensions
    {
        public static IServiceCollection RegisterServicesFromAttributes(this IServiceCollection services, Assembly assembly)
        {
           
            var typesWithInjectableAttribute = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<InjectableAttribute>() != null);

            foreach (var type in typesWithInjectableAttribute)
            {
                var attribute = type.GetCustomAttribute<InjectableAttribute>();

                if (attribute == null)
                    continue;

               
                if (attribute.ContractType != null)
                {
            
                    if (!services.Any(s => s.ServiceType == attribute.ContractType))
                    {
                        services.Add(new ServiceDescriptor(attribute.ContractType, type, attribute.Lifetime));
                    }
                }
                else
                {
                    
                    var interfacesToRegister = type.GetInterfaces()
                        .Except(type.BaseType?.GetInterfaces() ?? Array.Empty<Type>());

                    if (interfacesToRegister.Any())
                    {
                        
                        foreach (var iface in interfacesToRegister)
                        {
                            if (!services.Any(s => s.ServiceType == iface))
                            {
                                services.Add(new ServiceDescriptor(iface, type, attribute.Lifetime));
                            }
                        }
                    }
                    else
                    {
                        
                        if (!services.Any(s => s.ServiceType == type))
                        {
                            services.Add(new ServiceDescriptor(type, type, attribute.Lifetime));
                        }
                    }
                }
            }

            return services;
        }
    }
}
