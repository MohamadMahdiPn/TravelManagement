using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries.Handler;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries;

public class GetTravelerCheckList:IQuery<TravelCheckListDto>, IQuery<GetTravelerCheckListHandler>
{
    public Guid Id { get; set; }
}