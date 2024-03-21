namespace ClinicManager.Domain.Primitives.Errors;

public class AppointmentDomainErrors
{
    public static Error AppointmentNotFound = new("Appointment.NotFound", "This appointment was not found.");

}