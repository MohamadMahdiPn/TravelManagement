using TravelManagement.Application.DTO;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries;

public class GetTravelCheckList:IQuery<TravelCheckListDto>
{
    public Guid Id { get; set; }
}