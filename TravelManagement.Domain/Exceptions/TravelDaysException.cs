﻿using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions;
internal class InvalidTravelDaysException : TravelCheckListException
{
    public ushort Days { get; }

    public InvalidTravelDaysException(ushort days) : base($"Value '{days}' is invalid travel days.")
        => Days = days;
}