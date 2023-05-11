using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Temperature;

internal sealed class LowTemperaturePolicy : ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Temperature < 10D;

    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Winter hat", 1),
            new("Scarf", 1),
            new("Gloves", 1),
            new("Hoodie", 1),
            new("Warm jacket", 1),
        };
}