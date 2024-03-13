using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core;

public class Schedule : Entity
{
    public List<Appointment> Appointments { get; private set; }
}