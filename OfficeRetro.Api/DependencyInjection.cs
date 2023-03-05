using Microsoft.AspNetCore.Mvc.Infrastructure;
using OfficeRetro.Api.Exceptions;
using OfficeRetro.Api.Mappers;

namespace OfficeRetro.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, OfficeRetroProblemDetailsFactory>();

        services.AddMappings();

        return services;
    }
}
