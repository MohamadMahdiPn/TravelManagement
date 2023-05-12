using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions;

public class TravelCheckListNotFound : TravelCheckListException
{
    public Guid Id { get; }

    public TravelCheckListNotFound(Guid id) : base($"Traveler CheckList list with ID '{id}' was not found.")
        => Id = id;
}