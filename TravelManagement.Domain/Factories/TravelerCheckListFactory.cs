using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Policies;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories;

public sealed class TravelCheckListFactory : ITravelCheckListFactory
{

    private readonly IEnumerable<ITravelerItemsPolicy> _policies;


    public TravelCheckListFactory(IEnumerable<ITravelerItemsPolicy> policies)
        => _policies = policies;

    public TravelCheckList Create(TravelCheckListId id, TravelCheckListName name, TravelCheckListDestination destination)
        => new(id, name, destination);

    public TravelCheckList CreateWithDefaultItems(TravelCheckListId id, TravelCheckListName name, TravelDays days, Gender gender,
        Temperature temperature, TravelCheckListDestination destination)
    {
        var data = new PolicyData(days, gender, temperature, destination);
        var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

        var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
        var travelerCheckingList = Create(id, name, destination);

        travelerCheckingList.AddItems(items);

        return travelerCheckingList;
    }

}