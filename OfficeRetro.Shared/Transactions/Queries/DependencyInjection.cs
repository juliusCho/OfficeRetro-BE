using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Shared.Transactions.Queries.Interfaces;
using System.Reflection;

namespace OfficeRetro.Shared.Transactions.Queries;

public static class DependencyInjection
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();

        services.Scan(tss => tss.FromAssemblies(assembly)
            .AddClasses(itf => itf.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
