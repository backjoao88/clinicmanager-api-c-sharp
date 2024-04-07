using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Core.Doctors.Specialities;
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
    /// <param name="email"></param>
    /// <param name="idSpeciality"></param>
    public Doctor(string firstName, string lastName, string email, Guid idSpeciality)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdSpeciality = idSpeciality;
    }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public Guid IdSpeciality { get; private set; }
    public Speciality Speciality { get; private set; } = null!;
    private List<Schedule> _schedules = new();
    public List<Schedule> Schedules
    {
        get => _schedules;
        private set => _schedules = value;
    }
}