using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions;

public class TravelerCheckListAlreadyExistsException : TravelerCheckListException
{
    public string Name { get; }

    public TravelerCheckListAlreadyExistsException(string name)
        : base($"Traveler Check List with name '{name}' already exists.")
    {
        Name = name;
    }
}