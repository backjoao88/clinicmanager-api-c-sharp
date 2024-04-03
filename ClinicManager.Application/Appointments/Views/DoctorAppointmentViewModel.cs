using ClinicManager.Domain.Core.Appointments.Enumerations;

namespace ClinicManager.Application.Appointments.Views;

/// <summary>
/// Represents a simple a appointment view model.
/// </summary>
public class DoctorAppointmentViewModel
{
    public DoctorAppointmentViewModel(Guid idPatient, DateTime start, DateTime end, EAppointmentStatus status)
    {
        IdPatient = idPatient;
        Start = start;
        End = end;
        Status = status == EAppointmentStatus.WaitingConfirmation ? "WAITING_CONFIRMATION" :
            (status == EAppointmentStatus.Confirmed ? "CONFIRMED" : (status == EAppointmentStatus.Canceled ? "CANCELED" : "UNKNOWN"));
    }
    public Guid IdPatient { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Status { get; set; }
}