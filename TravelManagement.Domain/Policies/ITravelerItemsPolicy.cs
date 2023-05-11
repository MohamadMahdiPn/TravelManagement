using TravelManagement.Domain.Consts;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies;

public interface ITravelerItemsPolicy
{
    bool IsApplicable(PolicyData data);
    IEnumerable<TravelerItem> GenerateItems(PolicyData data);
}