using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Commands.Patients.Create;

/// <summary>
/// Represents the command to create a patient command.
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