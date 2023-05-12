using TravelManagement.Application.DTO;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries;

public class GetTravelerCheckList:IQuery<TravelCheckListDto>
{
    public Guid Id { get; set; }
}