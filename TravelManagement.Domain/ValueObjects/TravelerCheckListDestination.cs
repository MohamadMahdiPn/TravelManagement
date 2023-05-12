namespace TravelManagement.Domain.ValueObjects;

public record TravelCheckListDestination(string City , string Country)
{
    public static TravelCheckListDestination Create(string value)
    {
        var splitDestination = value.Split(',');
        return new (splitDestination.First() , splitDestination.Last());
    }


    public override string ToString() => $"{City} , {Country}";


}