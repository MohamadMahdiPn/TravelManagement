using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record RemoveTravelerItem(Guid TravelerCheckListId, string Name) : ICommand;