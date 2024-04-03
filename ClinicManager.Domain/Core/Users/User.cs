using ClinicManager.Domain.Core.Users.Enumerations;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Users;

/// <summary>
/// Represents an user entity.
/// </summary>
public class User : Entity
{
    public User(string email, string password, ERole role)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Role = role;
    }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public ERole Role { get; private set; }
}