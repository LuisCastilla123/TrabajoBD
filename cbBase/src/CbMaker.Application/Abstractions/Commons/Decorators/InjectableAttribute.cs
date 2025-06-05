using System;
using Microsoft.Extensions.DependencyInjection;

namespace CbMaker.Application.Common.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class InjectableAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }
        public Type? ContractType { get; }

        public InjectableAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Lifetime = lifetime;
            ContractType = null; 
        }

        public InjectableAttribute(Type contractType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Lifetime = lifetime;
            ContractType = contractType;
        }
    }
}
