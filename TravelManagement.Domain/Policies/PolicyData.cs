using TravelManagement.Domain.Consts;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies;

public record PolicyData(TravelDays Days, Gender Gender, Temperature Temperature,
    TravelerCheckListDestination Destination);
