using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core;

/// <inheritdoc/>>
public class Doctor : Entity
{
    private Doctor()
    {
    }

    public Doctor(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;

    /// <summary>
    /// Checks if the current doctor is available in a range of dates.
    /// </summary>
    /// <returns></returns>
    public bool IsAvailable(TimeSpan start, TimeSpan end)
    {
        return false;
    }
}