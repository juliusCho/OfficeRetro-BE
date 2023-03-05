using Microsoft.Extensions.DependencyInjection;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Shared.Transactions.Commands;

internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    async Task ICommandDispatcher.CommandAsync<TCommand>(TCommand command)
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command);
    }
}
