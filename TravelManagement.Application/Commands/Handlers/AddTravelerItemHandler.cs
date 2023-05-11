using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

internal sealed class AddTravelerItemHandler : ICommandHandler<AddTravelerItem>
{
    private readonly ITravelerCheckListRepository _repository;

    public AddTravelerItemHandler(ITravelerCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(AddTravelerItem command)
    {
        var travelerCheckingList = await _repository.GetAsync(command.TravelerCheckListId);

        if (travelerCheckingList is null)
        {
            throw new TravelerCheckListNotFound(command.TravelerCheckListId);
        }

        var travelerItem = new TravelerItem(command.Name, command.Quantity);
        travelerCheckingList.AddItem(travelerItem);

        await _repository.UpdateAsync(travelerCheckingList);
    }
}