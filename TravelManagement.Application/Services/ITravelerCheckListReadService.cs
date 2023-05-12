namespace TravelManagement.Application.Services;

public interface ITravelerCheckListReadService
{
    Task<bool> ExistsByNameAsync(string name);
}