using Microsoft.EntityFrameworkCore;
using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries;
using TravelManagement.Domain.Repositories;
using TravelManagement.Infrastructure.Ef.Contexts;
using TravelManagement.Infrastructure.Ef.Models;
using TravelManagement.Infrastructure.Ef.Queries;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Infrastructure.Queries.Handler;

internal sealed class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelCheckListDto>
{
    private readonly DbSet<TravelerCheckListReadModel> _TravelerCheckLists;

    public GetTravelerCheckListHandler(ReadDbContext context)
        => _TravelerCheckLists = context.TravelerCheckList;

    public Task<TravelCheckListDto> HandleAsync(GetTravelerCheckList query)
        => _TravelerCheckLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}