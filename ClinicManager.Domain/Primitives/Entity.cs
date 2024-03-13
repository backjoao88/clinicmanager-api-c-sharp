namespace ClinicManager.Domain.Primitives;

/// <summary>
/// Represents an entity.
/// </summary>
public abstract class Entity : IEquatable<Guid>
{
    public Guid Id { get; protected set; }
    
    public bool Equals(Guid other)
    {
        return Id == other;
    }
}