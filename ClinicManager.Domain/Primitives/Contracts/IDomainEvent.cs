using MediatR;

namespace ClinicManager.Domain.Primitives.Contracts;

/// <summary>
/// Represents a contract to define a domain event.
/// </summary>
public interface IDomainEvent : INotification;