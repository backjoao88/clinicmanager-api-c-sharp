using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Patients.Commands.Create;

/// <summary>
/// Represents the command to create a patient.
/// </summary>
public class CreatePatientCommand : IRequest<Result>
{
    public CreatePatientCommand(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}