using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories;

public interface ITravelCheckListFactory
{
    TravelCheckList Create(TravelCheckListId id, TravelCheckListName name, TravelCheckListDestination destination);

    TravelCheckList CreateWithDefaultItems(TravelCheckListId id, TravelCheckListName name, TravelDays days, Gender gender,
        Temperature temperature, TravelCheckListDestination destination);
}