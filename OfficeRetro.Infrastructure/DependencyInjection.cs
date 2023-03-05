using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer;
using OfficeRetro.Infrastructure.EF.Domains;
using OfficeRetro.Shared.Transactions.Queries;

namespace OfficeRetro.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddMSSqlServer(configuration);

        services.AddQueries();

        services.AddRepositories();

        return services;
    }
}
