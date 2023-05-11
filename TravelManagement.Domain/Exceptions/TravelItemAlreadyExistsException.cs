using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;

public class TravelItemAlreadyExistsException:TravelerCheckListException
{
    public string ListName { get;  }
    public string ItemName { get; }
    public TravelItemAlreadyExistsException(string listName , string itemName)
        :base($"Travel Check List '{listName}' is already defined item '{itemName}'")
    {
        ListName = listName;
        ItemName = itemName;
    }
    
}