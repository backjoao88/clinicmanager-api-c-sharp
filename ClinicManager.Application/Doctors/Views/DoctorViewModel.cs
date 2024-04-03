namespace ClinicManager.Application.Doctors.Views;

/// <summary>
/// Represents a patient view model.
/// </summary>
public class DoctorViewModel
{
    public DoctorViewModel(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}