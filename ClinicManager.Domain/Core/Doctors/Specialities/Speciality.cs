using ClinicManager.Domain.Core.Doctors.Enumerations;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors.Specialities;

/// <summary>
/// Represent a doctor speciality.
/// </summary>
public class Speciality : Entity
{
    public Speciality(ESpecialityArea specialityArea)
    {
        Id = Guid.NewGuid();
        SpecialityArea = specialityArea;
    }
    public ESpecialityArea SpecialityArea { get; set; }
}