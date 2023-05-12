using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record RemoveTravelerItem(Guid TravelCheckListId, string Name) : ICommand;