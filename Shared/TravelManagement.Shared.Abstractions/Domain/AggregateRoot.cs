namespace TravelManagement.Shared.Abstractions.Domain;

public class AggregateRoot<T>
{
    public T Id { get; set; }
    public int Version { get; set; }
    private bool _versionIncremented;

    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}