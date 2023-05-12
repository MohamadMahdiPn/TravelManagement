using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Shared.Commands;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}