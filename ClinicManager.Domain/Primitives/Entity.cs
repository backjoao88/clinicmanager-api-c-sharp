using ClinicManager.Domain.Primitives.Contracts;

namespace ClinicManager.Domain.Primitives;

/// <summary>
/// Represents an entity.
/// </summary>
public abstract class Entity : IEquatable<Guid>
{
    public Guid Id { get; protected set; }

    private List<IDomainEvent> _events = new();
    public List<IDomainEvent> Events
    {
        get => _events;
        private set => _events = value;
    }

    /// <summary>
    /// Raises a new domain event into the entity.
    /// </summary>
    /// <param name="domainEvent"></param>
    public void Raise(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }
    
    public bool Equals(Guid other)
    {
        return Id == other;
    }
}