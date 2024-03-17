using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Appointments;

public class Appointment : Entity
{
    public Appointment(Guid idDoctor, Guid idPatient, DateTime start, DateTime end)
    {
        IdDoctor = idDoctor;
        IdPatient = idPatient;
        Start = start;
        End = end;
    }
    public Guid IdDoctor { get; private set; }
    public Doctor Doctor { get; private set; } = null!;
    public Guid IdPatient { get; private set; }
    public Patient Patient { get; private set; } = null!;
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
}