using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions;

public class MissingDestinationWeatherException : TravelerCheckListException
{
    public TravelerCheckListDestination Destination { get; }

    public MissingDestinationWeatherException(TravelerCheckListDestination destination)
        : base($"Couldn't fetch weather data for Destination '{destination.Country}/{destination.City}'.")
    {
        Destination = destination;
    }
}