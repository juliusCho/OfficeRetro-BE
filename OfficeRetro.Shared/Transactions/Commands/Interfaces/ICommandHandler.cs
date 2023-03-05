namespace OfficeRetro.Shared.Transactions.Commands.Interfaces;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command);
}
