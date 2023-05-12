using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

internal sealed class AddTravelerItemHandler : ICommandHandler<AddTravelerItem>
{
    private readonly ITravelCheckListRepository _repository;

    public AddTravelerItemHandler(ITravelCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(AddTravelerItem command)
    {
        var travelerCheckingList = await _repository.GetAsync(command.TravelCheckListId);

        if (travelerCheckingList is null)
        {
            throw new TravelCheckListNotFound(command.TravelCheckListId);
        }

        var travelerItem = new TravelerItem(command.Name, command.Quantity);
        travelerCheckingList.AddItem(travelerItem);

        await _repository.UpdateAsync(travelerCheckingList);
    }
}