﻿using TravelManagement.Domain.Events;
using TravelManagement.Domain.Exceptions;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Domain;

namespace TravelManagement.Domain.Entities;

public class TravelCheckList: AggregateRoot<TravelCheckListId>
{
    #region Constructor

     internal TravelCheckList(TravelCheckListId id, TravelCheckListName name,
        TravelCheckListDestination destination)
    {
        Id=id;
        name = _name;
        destination = _destination;
    }

    public TravelCheckList(TravelCheckListId id , 
        TravelCheckListName name , TravelCheckListDestination destination , LinkedList<TravelerItem> items)
        :this(id , name ,destination)

    {
        _items = items;
    }

    public TravelCheckList()
    {
        
    }

    #endregion
   
    public TravelCheckListId Id { get; private set; }
    private TravelCheckListName _name;
    private TravelCheckListDestination _destination;

    private readonly LinkedList<TravelerItem> _items = new ();

    #region Functions

    public void AddItem(TravelerItem item)
    {
        var alreadyExists = _items.Any(x => x.Name == item.Name);
        if (alreadyExists)
        {
            throw new TravelItemAlreadyExistsException(_name , item.Name);
        }

        _items.AddLast(item);
        AddEvent(new TravelerItemAdded(this,item));
    }

    public void AddItems(IEnumerable<TravelerItem> items)
    {
        foreach (var travelerItem in items)
        {
            AddItem(travelerItem);
        }
    }

    public void TakeItem(string itemName)
    {
        var item = GetItem(itemName);
        var travelerItem = item with{ IsTaken = true};
        _items.Find(item).Value = travelerItem;
        AddEvent(new TravelerItemTaken(this, item));
    }

    private TravelerItem GetItem(string itemName)
    {
        var item = _items.SingleOrDefault(x => x.Name == itemName);
        if (item is null)
        {
            throw new TravelerItemNotFoundException(itemName);
        }
        return item;
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);
        _items.Remove(item);
        AddEvent(new TravelerItemRemoved(this, item));
    }




    #endregion

}