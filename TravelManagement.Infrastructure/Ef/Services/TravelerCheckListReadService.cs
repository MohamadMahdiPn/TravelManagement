using Microsoft.EntityFrameworkCore;
using TravelManagement.Application.Services;
using TravelManagement.Infrastructure.Ef.Contexts;
using TravelManagement.Infrastructure.Ef.Models;

namespace TravelManagement.Infrastructure.Ef.Services;

internal sealed class TravelCheckListReadService : ITravelCheckListReadService
{
    private readonly DbSet<TravelCheckListReadModel> _TravelCheckList;

    public TravelCheckListReadService(ReadDbContext context)
        => _TravelCheckList = context.TravelCheckList;

    public Task<bool> ExistsByNameAsync(string name)
        => _TravelCheckList.AnyAsync(pl => pl.Name == name);
}