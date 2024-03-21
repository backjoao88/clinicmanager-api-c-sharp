using ClinicManager.Domain.Primitives.Contracts;

namespace ClinicManager.Domain.Core.Appointments.Events;

/// <summary>
/// Represents an appointment scheduled domain event.
/// </summary>
public class AppointmentScheduledDomainEvent : IDomainEvent
{
    public AppointmentScheduledDomainEvent(Guid idPatient, Guid idDoctor, DateOnly day, TimeOnly start, TimeOnly end)
    {
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        Day = day;
        Start = start;
        End = end;
    }
    public Guid IdPatient { get; set; }
    public Guid IdDoctor { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}