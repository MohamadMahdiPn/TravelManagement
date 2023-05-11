using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Domain;

namespace TravelManagement.Domain.Entities;

public class TravelCheckList: AggregateRoot<TravelerCheckListId>
{
    #region Constructor

     internal TravelCheckList(TravelerCheckListId id, TravelerCheckListName name,
        TravelerCheckListDestination destination)
    {
        Id=id;
        name = _name;
        destination = _destination;
    }

    public TravelCheckList(TravelerCheckListId id , 
        TravelerCheckListName name , TravelerCheckListDestination destination , LinkedList<TravelerItem> items)
        :this(id , name ,destination)

    {
        _items = items;
    }

    public TravelCheckList()
    {
        
    }

    #endregion
   
    public TravelerCheckListId Id { get; private set; }
    private TravelerCheckListName _name;
    private TravelerCheckListDestination _destination;

    private readonly LinkedList<TravelerItem> _items = new ();
}