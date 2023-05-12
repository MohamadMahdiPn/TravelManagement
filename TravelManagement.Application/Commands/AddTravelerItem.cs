
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record AddTravelerItem(Guid TravelCheckListId, string Name, uint Quantity) : ICommand;
