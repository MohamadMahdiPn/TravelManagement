﻿using TravelManagement.Application.Services;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers;

public class CreateTravelerCheckListWithItemsHandler : ICommandHandler<CreateTravelerCheckListWithItems>
{
    private readonly ITravelerCheckListRepository _repository;
    private readonly ITravelerCheckListFactory _factory;
    private readonly IWeatherService _weatherService;
    private readonly ITravelerCheckListReadService _readService;



    public CreateTravelerCheckListWithItemsHandler(ITravelerCheckListRepository repository, ITravelerCheckListFactory factory,
        IWeatherService weatherService, ITravelerCheckListReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _weatherService = weatherService;
        _readService = readService;
    }

    public async Task HandleAsync(CreateTravelerCheckListWithItems command)
    {
        var (id, name, days, gender, DestinationWriteModel) = command;


        if (await _readService.ExistsByNameAsync(name))
        {
            throw new TravelerCheckListAlreadyExistsException(name);
        }


        var destination = new Destination(DestinationWriteModel.City, DestinationWriteModel.Country);
        var weather = await _weatherService.GetWeatherAsync(destination);

        if (weather is null)
        {
            throw new MissingDestinationWeatherException(destination);
        }

        var TravelerCheckList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature,
            destination);

        await _repository.AddAsync(TravelerCheckList);
    }

}