using TravelManagement.Domain.Exceptions;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.ValueObjects;

public record TravelCheckListId
{
    public Guid Value { get; }

    public TravelCheckListId(Guid value)
    {
        if (value == Guid.Empty)
            throw new TravelCheckListIdException();
        Value = value;
    }

    public static implicit operator Guid(TravelCheckListId id) =>id.Value;
    public static implicit operator TravelCheckListId(Guid id) => new(id);
}