using Microsoft.EntityFrameworkCore;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Infrastructure.Ef.Contexts;

namespace TravelManagement.Infrastructure.Ef.Repositories;

internal sealed class TravelCheckListRepository : ITravelCheckListRepository
{
    private readonly DbSet<TravelCheckList> _TravelCheckList;
    private readonly WriteDbContext _writeDbContext;

    public TravelCheckListRepository(WriteDbContext writeDbContext)
    {
        _TravelCheckList = writeDbContext.TravelCheckLists;
        _writeDbContext = writeDbContext;
    }

    public Task<TravelCheckList> GetAsync(TravelCheckListId id)
        => _TravelCheckList.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(TravelCheckList TravelCheckList)
    {
        await _TravelCheckList.AddAsync(TravelCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TravelCheckList TravelCheckList)
    {
        _TravelCheckList.Update(TravelCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TravelCheckList TravelCheckList)
    {
        _TravelCheckList.Remove(TravelCheckList);
        await _writeDbContext.SaveChangesAsync();
    }
}