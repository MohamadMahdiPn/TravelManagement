using Microsoft.EntityFrameworkCore;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Infrastructure.Ef.Contexts;

namespace TravelManagement.Infrastructure.Ef.Repositories;

internal sealed class TravelerCheckListRepository : ITravelerCheckListRepository
{
    private readonly DbSet<TravelCheckList> _travelerCheckList;
    private readonly WriteDbContext _writeDbContext;

    public TravelerCheckListRepository(WriteDbContext writeDbContext)
    {
        _travelerCheckList = writeDbContext.TravelerCheckLists;
        _writeDbContext = writeDbContext;
    }

    public Task<TravelCheckList> GetAsync(TravelerCheckListId id)
        => _travelerCheckList.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(TravelCheckList travelerCheckList)
    {
        await _travelerCheckList.AddAsync(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TravelCheckList travelerCheckList)
    {
        _travelerCheckList.Update(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TravelCheckList travelerCheckList)
    {
        _travelerCheckList.Remove(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }
}