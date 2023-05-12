using TravelManagement.Application.DTO;
using TravelManagement.Infrastructure.Ef.Models;

namespace TravelManagement.Infrastructure.Ef.Queries;

internal static class Extensions
{
    public static TravelCheckListDto AsDto(this TravelerCheckListReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Destination = new DestinationDto
            {
                City = readModel.Destination?.City,
                Country = readModel.Destination?.Country
            },
            Items = readModel.Items?.Select(pi => new TravelItemDto
            {
                Name = pi.Name,
                Quantity = pi.Quantity,
                IsTaken = pi.IsTaken,
            })
        };
}