using Microsoft.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class InjectableAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; }
    public Type? ContractType { get; }

    public InjectableAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
        ContractType = null; // No tiene contrato explícito
    }

    public InjectableAttribute(Type contractType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
        ContractType = contractType;
    }
}
