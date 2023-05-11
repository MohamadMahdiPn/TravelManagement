using TravelManagement.Application.DTO.External;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(TravelerCheckListDestination localization);
}