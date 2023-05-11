namespace TravelManagement.Domain.Exceptions;

public class TravelerItemNameException:Exception
{
    public TravelerItemNameException():base("Traveler item name cannot be empty.")
    {
        
    }
}