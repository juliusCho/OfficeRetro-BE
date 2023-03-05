namespace OfficeRetro.Shared.Transactions.Commands.Interfaces;

public interface ICommandDispatcher
{
    Task CommandAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}
