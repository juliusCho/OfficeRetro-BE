namespace OfficeRetro.Shared.Domain;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    protected AggregateRoot(TId id) : base(id) { }

    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    private readonly List<IDomainEvent> _events = new();
    private bool _versionIncremented;

    protected void IncrementVersion()
    {
        if (_versionIncremented) return;

        Version += 1;
        _versionIncremented = true;
    }

    /**TODO: Why does the version get incremented only once?*/
    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any()) IncrementVersion();

        _events.Add(@event);
    }

    public void ClearEvents() => _events.Clear();
}
