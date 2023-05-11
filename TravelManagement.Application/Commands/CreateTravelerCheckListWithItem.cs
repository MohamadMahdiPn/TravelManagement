using TravelManagement.Domain.Consts;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands;

public record CreateTravelerCheckListWithItems(Guid Id, string Name, ushort Days, Gender Gender,
    DestinationWriteModel Destionation) : ICommand;

public record DestinationWriteModel(string City, string Country);
