using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions;

public class TravelCheckListAlreadyExistsException : TravelCheckListException
{
    public string Name { get; }

    public TravelCheckListAlreadyExistsException(string name)
        : base($"Traveler Check List with name '{name}' already exists.")
    {
        Name = name;
    }
}