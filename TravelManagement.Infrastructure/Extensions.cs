using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelManagement.Application.Services;
using TravelManagement.Infrastructure.Ef;
using TravelManagement.Infrastructure.Logging;
using TravelManagement.Infrastructure.Services;
using TravelManagement.Shared.Abstractions.Commands;
using TravelManagement.Shared.Queries;

namespace TravelManagement.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlDb(configuration);
        services.AddQueries();
        services.AddSingleton<IWeatherService, WeatherService>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}