using TravelManagement.Domain.Consts;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies;

public record PolicyData(TravelDays Days, Consts.Gender Gender, ValueObjects.Temperature Temperature,
    TravelCheckListDestination Destination);
