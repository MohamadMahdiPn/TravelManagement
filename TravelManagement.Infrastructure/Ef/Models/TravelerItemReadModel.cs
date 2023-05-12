namespace TravelManagement.Infrastructure.Ef.Models;

internal class TravelerItemReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public uint Quantity { get; set; }
    public bool IsTaken { get; set; }

    public TravelCheckListReadModel TravelCheckList { get; set; }
}