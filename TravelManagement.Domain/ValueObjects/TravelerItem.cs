using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects;

public class TravelerItem
{
    public string Name { get; }
    public uint Quantity { get;  }
    public bool IsTaken { get; }

    public TravelerItem(string name , uint quantity, bool isTaken = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new TravelerItemNameException();
        }
        Name = name;
        Quantity = quantity;
        IsTaken = isTaken;
    }
}