using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories;

public interface ITravelerCheckListFactory
{
    TravelCheckList Create(TravelerCheckListId id, TravelerCheckListName name, TravelerCheckListDestination destination);

    TravelCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days, Gender gender,
        Temperature temperature, TravelerCheckListDestination destination);
}