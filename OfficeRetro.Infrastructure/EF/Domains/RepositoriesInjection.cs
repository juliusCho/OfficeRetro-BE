using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Domain.Inquiry.Repositories;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Repositories;
using System.Reflection;

namespace OfficeRetro.Infrastructure.EF.Domains;

internal static class RepositoriesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddScoped<IInquiryRepository, InquiryRepository>();

        return services;
    }

    private static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
