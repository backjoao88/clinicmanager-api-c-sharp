using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core;

/// <summary>
/// Represents an appointment.
/// </summary>
public class Appointment : Entity
{
    public Guid IdDoctor { get; private set; }
    public Doctor Doctor { get; private set; } = null!;
}