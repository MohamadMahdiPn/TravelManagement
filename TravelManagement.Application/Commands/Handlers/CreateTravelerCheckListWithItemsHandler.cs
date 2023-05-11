using TravelManagement.Application.Exceptions;
using TravelManagement.Application.Services;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

public class CreateTravelerCheckListWithItemsHandler : ICommandHandler<CreateTravelerCheckListWithItems>
{
    private readonly ITravelerCheckListRepository _repository;
    private readonly ITravelerCheckListFactory _factory;
    private readonly IWeatherService _weatherService;
   



    public CreateTravelerCheckListWithItemsHandler(ITravelerCheckListRepository repository, ITravelerCheckListFactory factory,
        IWeatherService weatherService)
    {
        _repository = repository;
        _factory = factory;
        _weatherService = weatherService;
        
    }

    public async Task HandleAsync(CreateTravelerCheckListWithItems command)
    {
        var (id, name, days, gender, destinationWriteModel) = command;


        var destination = new TravelerCheckListDestination(destinationWriteModel.City, destinationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(destination);

        if (weather is null)
        {
            throw new MissingDestinationWeatherException(destination);
        }

        var travelerCheckList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature,
            destination);

        await _repository.AddAsync(travelerCheckList);
    }

}