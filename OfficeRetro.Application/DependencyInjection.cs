using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Domain.Inquiry.Factories;
using OfficeRetro.Domain.Inquiry.Factories.Interfaces;
using OfficeRetro.Shared.Transactions.Commands;

namespace OfficeRetro.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();

        services.AddSingleton<IInquiryFactory, InquiryFactory>();

        //services.Scan(tss => tss.FromAssemblies(typeof(IPackingItemPolicy).Assembly)
        //    .AddClasses(itf => itf.AssignableTo<IPackingItemsPolicy>())
        //    .AsImplementedInterfaces()
        //    .WithSingletonLifetime());

        return services;
    }
}
