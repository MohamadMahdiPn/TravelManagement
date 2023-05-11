using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;

public class TravelerCheckListNameException:TravelerCheckListException
{
    public TravelerCheckListNameException() : base("traveler checklist Id Cannot be empty")
    {
        
    }
}