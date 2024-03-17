using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Patients;

/// <inheritdoc/>>
public class Patient : Entity
{
    private Patient()
    {
    }

    public Patient(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
}