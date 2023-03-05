using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace OfficeRetro.Contracts;

public static class DependencyInjection
{
    public static IServiceCollection AddContracts(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        return services;
    }
}
