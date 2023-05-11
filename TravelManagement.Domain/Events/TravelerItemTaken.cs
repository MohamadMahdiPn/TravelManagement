﻿using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Domain;

namespace TravelManagement.Domain.Events;

public record TravelerItemTaken(TravelCheckList TravelerCheckList, TravelerItem TravelerItem) : IDomainEvent;