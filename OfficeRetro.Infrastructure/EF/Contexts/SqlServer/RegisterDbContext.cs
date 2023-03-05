using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write;
using OfficeRetro.Infrastructure.EF.Options;
using OfficeRetro.Shared;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer;

internal static class RegisterDbContext
{
    public static IServiceCollection AddMSSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<SqlServerOptions>("SqlServer");

        services.AddDbContext<ReadDbContext>(option =>
        {
            option.UseSqlServer(options.ConnectionString);
        });
        services.AddDbContext<WriteDbContext>(option =>
        {
            option.UseSqlServer(options.ConnectionString);
        });

        return services;
    }
}
