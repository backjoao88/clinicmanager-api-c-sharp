using ClinicManager.Domain.Core.Appointments.Enumerations;
using ClinicManager.Domain.Core.Appointments.Events;
using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Appointments;

public class Appointment : Entity
{
    private Appointment(Guid idDoctor, Guid idPatient, DateTime start, DateTime end)
    {
        IdDoctor = idDoctor;
        IdPatient = idPatient;
        Start = start;
        End = end;
        Status = EAppointmentStatus.WaitingConfirmation;
    }
    public Guid IdDoctor { get; private set; }
    public Doctor Doctor { get; private set; } = null!;
    public Guid IdPatient { get; private set; }
    public Patient Patient { get; private set; } = null!;
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public EAppointmentStatus Status { get; private set; }

    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="idDoctor"></param>
    /// <param name="idPatient"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Appointment Create(Guid idDoctor, Guid idPatient, DateTime start, DateTime end)
    {
        var appointment = new Appointment(idDoctor, idPatient, start, end);
        var appointmentDay = new DateOnly(start.Year, start.Month, start.Day);
        var startAppointmentTime = new TimeOnly(start.Hour, start.Minute);
        var endAppointmentTime = new TimeOnly(end.Hour, end.Minute);
        appointment.Raise(new AppointmentScheduledDomainEvent(idPatient, idDoctor, appointmentDay, startAppointmentTime, endAppointmentTime));
        return appointment;
    }

    /// <summary>
    /// Confirms an appointment.
    /// </summary>
    public void Confirm()
    {
        Status = EAppointmentStatus.Confirmed;
    }
    
}