using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions;

public class TravelerCheckListNotFound : TravelerCheckListException
{
    public Guid Id { get; }

    public TravelerCheckListNotFound(Guid id) : base($"Traveler CheckList list with ID '{id}' was not found.")
        => Id = id;
}s