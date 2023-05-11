namespace TravelManagement.Domain.ValueObjects;

public record TravelerCheckListDestination(string City , string Country)
{
    public static TravelerCheckListDestination Create(string value)
    {
        var splitDestination = value.Split(',');
        return new (splitDestination.First() , splitDestination.Last());
    }


    public override string ToString() => $"{City} , {Country}";


}