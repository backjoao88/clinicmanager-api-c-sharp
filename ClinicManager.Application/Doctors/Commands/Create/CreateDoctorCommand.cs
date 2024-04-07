using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Doctors.Commands.Create;

/// <summary>
/// Represents a command to create a doctor.
/// </summary>
public class CreateDoctorCommand : IRequest<Result>
{
    public CreateDoctorCommand(string firstName, string lastName, string email, Guid idSpeciality)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdSpeciality = idSpeciality;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Guid IdSpeciality { get; set; }
}