using ClinicManager.Domain.Core.Users.Enumerations;

namespace ClinicManager.Application.Shared.Authentication;

public interface IJwtService
{
    /// <summary>
    /// Generates a JWT token.
    /// </summary>
    /// <returns></returns>
    public string Generate(Guid userId, ERole role);
    /// <summary>
    /// Encrypts a string.
    /// </summary>
    /// <returns></returns>
    public string Encrypt(string str);
}