using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions;

public class MissingDestinationWeatherException : TravelCheckListException
{
    public TravelCheckListDestination Destination { get; }

    public MissingDestinationWeatherException(TravelCheckListDestination destination)
        : base($"Couldn't fetch weather data for Destination '{destination.Country}/{destination.City}'.")
    {
        Destination = destination;
    }
}