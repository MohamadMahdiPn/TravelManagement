using TravelManagement.Application.Exceptions;
using TravelManagement.Application.Services;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

public class CreateTravelCheckListWithItemsHandler : ICommandHandler<CreateTravelCheckListWithItems>
{
    private readonly ITravelCheckListRepository _repository;
    private readonly ITravelCheckListFactory _factory;
    private readonly IWeatherService _weatherService;
   private readonly ITravelCheckListReadService _TravelCheckListReadService;



    public CreateTravelCheckListWithItemsHandler(ITravelCheckListRepository repository, ITravelCheckListFactory factory,
        IWeatherService weatherService, ITravelCheckListReadService TravelCheckListReadService)
    {
        _repository = repository;
        _factory = factory;
        _weatherService = weatherService;
        _TravelCheckListReadService = TravelCheckListReadService;
    }

    public async Task HandleAsync(CreateTravelCheckListWithItems command)
    {
        var (id, name, days, gender, destinationWriteModel) = command;

        if (await _TravelCheckListReadService.ExistsByNameAsync(name))
        {
            throw new TravelCheckListAlreadyExistsException(name);
        }


        var destination = new TravelCheckListDestination(destinationWriteModel.City, destinationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(destination);

        if (weather is null)
        {
            throw new MissingDestinationWeatherException(destination);
        }

        var TravelCheckList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature,
            destination);

        await _repository.AddAsync(TravelCheckList);
    }

}