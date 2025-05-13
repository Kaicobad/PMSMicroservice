
namespace Pms360.Domain.Abstractions;
public class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly IList<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] domainEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return domainEvents;
    }
}
