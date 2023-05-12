using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;

public class TravelCheckListIdException: TravelCheckListException
{
    public TravelCheckListIdException():base("traveler checklist Id Cannot be empty")
    {
        
    }
}