using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

internal sealed class TakeItemHandler : ICommandHandler<TakeItem>
{
    private readonly ITravelerCheckListRepository _repository;

    public TakeItemHandler(ITravelerCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(TakeItem command)
    {
        var travelerCheckList = await _repository.GetAsync(command.TravelerCheckListId);

        if (travelerCheckList is null)
        {
            throw new TravelerCheckListNotFound(command.TravelerCheckListId);
        }

        travelerCheckList.TakeItem(command.Name);

        await _repository.UpdateAsync(travelerCheckList);
    }
}