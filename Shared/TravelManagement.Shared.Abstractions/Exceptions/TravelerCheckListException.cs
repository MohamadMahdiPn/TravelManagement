namespace TravelManagement.Shared.Abstractions.Exceptions;

public abstract class TravelCheckListException:Exception
{
    protected TravelCheckListException(string message) : base(message)
    {

    }
    
}