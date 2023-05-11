using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;

public class TravelerCheckListIdException: TravelerCheckListException
{
    public TravelerCheckListIdException():base("traveler checklist Id Cannot be empty")
    {
        
    }
}