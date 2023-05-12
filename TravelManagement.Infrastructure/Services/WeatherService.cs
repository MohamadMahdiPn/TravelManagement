using TravelManagement.Application.DTO.External;
using TravelManagement.Application.Services;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Infrastructure.Services;

public class WeatherService:IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(TravelerCheckListDestination destination) =>
        Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
}