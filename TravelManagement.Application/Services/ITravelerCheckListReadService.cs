namespace TravelManagement.Application.Services;

public interface ITravelCheckListReadService
{
    Task<bool> ExistsByNameAsync(string name);
}