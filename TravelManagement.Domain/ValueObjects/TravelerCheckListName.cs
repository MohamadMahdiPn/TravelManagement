using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects;

public class TravelCheckListName
{
    public string Value { get; }

    public TravelCheckListName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new TravelCheckListNameException();
        }
        Value = value;

    }



    public static implicit  operator string (TravelCheckListName value) => value.Value;
    public static implicit  operator TravelCheckListName(string name) => new (name);
}