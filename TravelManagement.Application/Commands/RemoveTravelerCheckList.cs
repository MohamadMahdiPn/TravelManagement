using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record RemoveTravelerCheckList(Guid Id) : ICommand;