using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Repositories;

public interface ITravelCheckListRepository
{
    Task<TravelCheckList> GetAsync(TravelCheckListId id);
    Task AddAsync(TravelCheckList TravelCheckList);
    Task UpdateAsync(TravelCheckList TravelCheckList);
    Task DeleteAsync(TravelCheckList TravelCheckList);
}