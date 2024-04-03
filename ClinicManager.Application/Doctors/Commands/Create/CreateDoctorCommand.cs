using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Doctors.Commands.Create;

/// <summary>
/// Represents a command to create a doctor.
/// </summary>
public class CreateDoctorCommand : IRequest<Result>
{
    public CreateDoctorCommand(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}