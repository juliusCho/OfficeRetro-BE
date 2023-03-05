using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;
using System.Reflection;

namespace OfficeRetro.Shared.Transactions.Commands;

public static class DependencyInjection
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

        services.Scan(tss => tss.FromAssemblies(assembly)
            .AddClasses(itf => itf.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
