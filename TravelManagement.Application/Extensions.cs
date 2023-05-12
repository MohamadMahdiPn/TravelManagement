using Microsoft.Extensions.DependencyInjection;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Policies;
using TravelManagement.Shared.Commands;

namespace TravelManagement.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<ITravelerCheckListFactory, TravelerCheckListFactory>();

        services.Scan(b => b.FromAssemblies(typeof(ITravelerItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<ITravelerItemsPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}