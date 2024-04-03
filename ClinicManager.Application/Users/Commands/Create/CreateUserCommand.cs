using ClinicManager.Domain.Core.Users.Enumerations;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Users.Commands.Create;

/// <summary>
/// Represents the command to create a user.
/// </summary>
public class CreateUserCommand : IRequest<Result>
{
    public CreateUserCommand(string email, string password, ERole role)
    {
        Email = email;
        Password = password;
        Role = role;
    }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; }
}