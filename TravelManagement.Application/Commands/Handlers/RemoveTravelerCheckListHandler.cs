using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

internal sealed class RemoveTravelCheckListHandler : ICommandHandler<RemoveTravelCheckList>
{
    private readonly ITravelCheckListRepository _repository;

    public RemoveTravelCheckListHandler(ITravelCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemoveTravelCheckList command)
    {
        var TravelCheckList = await _repository.GetAsync(command.Id);

        if (TravelCheckList is null)
        {
            throw new TravelCheckListNotFound(command.Id);
        }

        await _repository.DeleteAsync(TravelCheckList);
    }
}