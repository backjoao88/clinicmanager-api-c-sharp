namespace ClinicManager.Application.Appointments.Views;

/// <summary>
/// Represents a simple a appointment view model.
/// </summary>
public class DoctorAppointmentViewModel
{
    public DoctorAppointmentViewModel(Guid idPatient, DateTime start, DateTime end)
    {
        IdPatient = idPatient;
        Start = start;
        End = end;
    }
    public Guid IdPatient { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}