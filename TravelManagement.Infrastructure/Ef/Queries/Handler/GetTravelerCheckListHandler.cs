using Microsoft.EntityFrameworkCore;
using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries;
using TravelManagement.Domain.Repositories;
using TravelManagement.Infrastructure.Ef.Contexts;
using TravelManagement.Infrastructure.Ef.Models;
using TravelManagement.Infrastructure.Ef.Queries;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Infrastructure.Queries.Handler;

internal sealed class GetTravelCheckListHandler : IQueryHandler<GetTravelCheckList, TravelCheckListDto>
{
    private readonly DbSet<TravelCheckListReadModel> _TravelCheckLists;

    public GetTravelCheckListHandler(ReadDbContext context)
        => _TravelCheckLists = context.TravelCheckList;

    public Task<TravelCheckListDto> HandleAsync(GetTravelCheckList query)
        => _TravelCheckLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}