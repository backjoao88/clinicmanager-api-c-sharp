using System.Net;
using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Patients;

/// <inheritdoc/>>
public class Patient : Entity
{
    /// <summary>
    /// Constructor for patient.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    public Patient(string firstName, string lastName, string email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}