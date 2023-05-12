using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

internal sealed class TakeItemHandler : ICommandHandler<TakeItem>
{
    private readonly ITravelCheckListRepository _repository;

    public TakeItemHandler(ITravelCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(TakeItem command)
    {
        var TravelCheckList = await _repository.GetAsync(command.TravelCheckListId);

        if (TravelCheckList is null)
        {
            throw new TravelCheckListNotFound(command.TravelCheckListId);
        }

        TravelCheckList.TakeItem(command.Name);

        await _repository.UpdateAsync(TravelCheckList);
    }
}