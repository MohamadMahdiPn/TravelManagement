using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelManagement.Application.Services;
using TravelManagement.Domain.Repositories;
using TravelManagement.Infrastructure.Ef.Contexts;
using TravelManagement.Infrastructure.Ef.Options;
using TravelManagement.Infrastructure.Ef.Repositories;
using TravelManagement.Infrastructure.Ef.Services;
using TravelManagement.Shared.Options;

namespace TravelManagement.Infrastructure.Ef;

internal static class Extensions
{
    public static IServiceCollection AddSqlDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITravelCheckListRepository, TravelCheckListRepository>();
        services.AddScoped<ITravelCheckListReadService, TravelCheckListReadService>();

        var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));

        return services;
    }
}