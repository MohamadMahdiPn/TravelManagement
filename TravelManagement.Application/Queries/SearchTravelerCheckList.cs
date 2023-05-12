using TravelManagement.Application.DTO;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries;

public class SearchTravelerCheckList:IQuery<IEnumerable<TravelCheckListDto>>
{
    public string SearchPhrase { get; set; }
}