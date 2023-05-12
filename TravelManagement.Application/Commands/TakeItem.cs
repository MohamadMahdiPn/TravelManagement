using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record TakeItem(Guid TravelCheckListId, string Name) : ICommand;