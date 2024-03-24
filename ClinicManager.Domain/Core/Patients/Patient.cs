using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Patients;

/// <inheritdoc/>>
public class Patient : Entity
{
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private Patient()
    {
    }
    
    /// <summary>
    /// Constructor for patient.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public Patient(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
}