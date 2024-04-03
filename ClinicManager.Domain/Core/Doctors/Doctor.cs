using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors;

/// <inheritdoc/>>
public class Doctor : Entity
{
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private Doctor()
    {
    }

    /// <summary>
    /// Constructor for doctor.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public Doctor(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    private List<Schedule> _schedules = new();
    public List<Schedule> Schedules
    {
        get => _schedules;
        private set => _schedules = value;
    }
}