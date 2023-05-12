using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Infrastructure.Queries.Handler;

public class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelCheckListDto>
{
    #region Constructor

    private readonly ITravelerCheckListRepository _travelerCheckListRepository;

    public GetTravelerCheckListHandler(ITravelerCheckListRepository travelerCheckListRepository)
    {
        _travelerCheckListRepository = travelerCheckListRepository;
    }



    #endregion

    public async Task<TravelCheckListDto> HandleAsync(GetTravelerCheckList query)
    {
        var travelerCheckList = await _travelerCheckListRepository.GetAsync(query.Id);
        //need to complete
        return null;
    }
}