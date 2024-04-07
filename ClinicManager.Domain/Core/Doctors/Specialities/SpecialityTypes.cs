using ClinicManager.Domain.Core.Doctors.Enumerations;

namespace ClinicManager.Domain.Core.Doctors.Specialities;

/// <summary>
/// Represents a set of available specialities.
/// </summary>
public class SpecialityTypes
{
    public static Speciality[] DefaultSpecialities =
    {
        new Speciality(ESpecialityArea.NEUROLOGISTA),
        new Speciality(ESpecialityArea.ORTOPEDISTA)
    };
}