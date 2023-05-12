using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record RemoveTravelCheckList(Guid Id) : ICommand;