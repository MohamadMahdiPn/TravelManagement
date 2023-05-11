using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;

public class TravelerItemNotFoundException:TravelerCheckListException
{
    public string ItemName { get; set; }
    public TravelerItemNotFoundException(string itemName):base($"Traveler item {itemName} not found")
    {
        ItemName = itemName;
    }
}