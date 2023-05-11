using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Policies;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories;

public sealed class TravelerCheckListFactory : ITravelerCheckListFactory
{

    private readonly IEnumerable<ITravelerItemsPolicy> _policies;


    public TravelerCheckListFactory(IEnumerable<ITravelerItemsPolicy> policies)
        => _policies = policies;

    public TravelCheckList Create(TravelerCheckListId id, TravelerCheckListName name, TravelerCheckListDestination destination)
        => new(id, name, destination);

    public TravelCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days, Gender gender,
        Temperature temperature, TravelerCheckListDestination destination)
    {
        var data = new PolicyData(days, gender, temperature, destination);
        var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

        var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
        var travelerCheckingList = Create(id, name, destination);

        travelerCheckingList.AddItems(items);

        return travelerCheckingList;
    }

}