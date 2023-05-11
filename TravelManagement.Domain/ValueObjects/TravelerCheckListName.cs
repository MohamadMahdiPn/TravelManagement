using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects;

public class TravelerCheckListName
{
    public string Value { get; }

    public TravelerCheckListName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new TravelerCheckListNameException();
        }
        Value = value;

    }



    public static implicit  operator string (TravelerCheckListName value) => value.Value;
    public static implicit  operator TravelerCheckListName(string name) => new (name);
}