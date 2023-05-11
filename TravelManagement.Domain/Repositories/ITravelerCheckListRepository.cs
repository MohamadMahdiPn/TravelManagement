using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Repositories;

public interface ITravelerCheckListRepository
{
    Task<TravelCheckList> GetAsync(TravelerCheckListId id);
    Task AddAsync(TravelCheckList travelerCheckList);
    Task UpdateAsync(TravelCheckList travelerCheckList);
    Task DeleteAsync(TravelCheckList travelerCheckList);
}