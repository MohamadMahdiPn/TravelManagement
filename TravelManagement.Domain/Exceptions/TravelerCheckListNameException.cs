using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;

public class TravelCheckListNameException:TravelCheckListException
{
    public TravelCheckListNameException() : base("traveler checklist Id Cannot be empty")
    {
        
    }
}