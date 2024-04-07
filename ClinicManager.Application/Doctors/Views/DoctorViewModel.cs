using ClinicManager.Domain.Core.Doctors.Enumerations;

namespace ClinicManager.Application.Doctors.Views;

/// <summary>
/// Represents a patient view model.
/// </summary>
public class DoctorViewModel
{
    public DoctorViewModel(Guid id, string firstName, string lastName, ESpecialityArea speciality)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Speciality = speciality;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ESpecialityArea Speciality { get; set; }
}