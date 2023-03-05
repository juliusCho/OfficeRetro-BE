namespace OfficeRetro.Shared.Transactions.Queries.Interfaces;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}
