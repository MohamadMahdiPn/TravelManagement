using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

internal sealed class RemoveTravelerItemHandler : ICommandHandler<RemoveTravelerItem>
{
    private readonly ITravelCheckListRepository _repository;

    public RemoveTravelerItemHandler(ITravelCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemoveTravelerItem command)
    {
        var travelerCheckingList = await _repository.GetAsync(command.TravelCheckListId);

        if (travelerCheckingList is null)
        {
            throw new TravelCheckListNotFound(command.TravelCheckListId);
        }

        travelerCheckingList.RemoveItem(command.Name);

        await _repository.UpdateAsync(travelerCheckingList);
    }
}