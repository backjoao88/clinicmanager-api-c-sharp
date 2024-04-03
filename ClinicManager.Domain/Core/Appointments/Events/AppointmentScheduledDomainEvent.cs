using ClinicManager.Domain.Primitives.Contracts;

namespace ClinicManager.Domain.Core.Appointments.Events;

/// <summary>
/// Represents an appointment scheduled domain event.
/// </summary>
public class AppointmentScheduledDomainEvent : IDomainEvent
{
    public AppointmentScheduledDomainEvent(Guid idAppointment, Guid idPatient, Guid idDoctor, DateOnly day, TimeOnly start, TimeOnly end, string confirmationCode)
    {
        IdAppointment = idAppointment;
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        Day = day;
        Start = start;
        End = end;
        ConfirmationCode = confirmationCode;
    }
    public Guid IdAppointment { get; set; }
    public Guid IdPatient { get; set; }
    public Guid IdDoctor { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public string ConfirmationCode { get; set; }
}