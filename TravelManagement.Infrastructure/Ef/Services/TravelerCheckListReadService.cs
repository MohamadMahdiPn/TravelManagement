using Microsoft.EntityFrameworkCore;
using TravelManagement.Application.Services;
using TravelManagement.Infrastructure.Ef.Contexts;
using TravelManagement.Infrastructure.Ef.Models;

namespace TravelManagement.Infrastructure.Ef.Services;

internal sealed class TravelerCheckListReadService : ITravelerCheckListReadService
{
    private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

    public TravelerCheckListReadService(ReadDbContext context)
        => _travelerCheckList = context.TravelerCheckList;

    public Task<bool> ExistsByNameAsync(string name)
        => _travelerCheckList.AnyAsync(pl => pl.Name == name);
}