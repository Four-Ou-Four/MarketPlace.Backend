using System.Reflection;
using MarketPlace.Domain.Common.Events;
using MassTransit;

namespace MarketPlace.Infrastructure.Common.EventBus.Extensions;

/// <summary>
/// Provides extension methods for MassTransit.
/// </summary>
public static class MassTransitExtensions
{
    /// <summary>
    /// Registers all the consumers form the assembly
    /// </summary>
    /// <param name="busConfigurator">MassTransit bus configuration</param>
    /// <param name="assemblies">Collection of assemblies to get consumers from</param>
    public static void RegisterAllConsumers(this IBusRegistrationConfigurator busConfigurator, ICollection<Assembly> assemblies)
    {
        var consumers = assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => !type.IsAbstract
                           && type.GetInterfaces().Any(implementedInterface =>
                               implementedInterface.IsGenericType
                               && implementedInterface.GetGenericTypeDefinition() == typeof(IEventHandler<>)));

        foreach (var consumer in consumers)
            busConfigurator.AddConsumer(consumer);
    }
}