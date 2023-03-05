using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Shared.Services;

namespace OfficeRetro.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddHostedService<AppInitializer>();

        return services;
    }
}
