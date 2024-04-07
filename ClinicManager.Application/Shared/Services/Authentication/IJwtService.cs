using ClinicManager.Domain.Core.Users.Enumerations;

namespace ClinicManager.Application.Shared.Services.Authentication;

public interface IJwtService
{
    /// <summary>
    /// Generates a token for authentication use-case.
    /// </summary>
    /// <returns></returns>
    public string GenerateAuthenticationToken(Guid userId, ERole role);
    /// <summary>
    /// Encrypts a string.
    /// </summary>
    /// <returns></returns>
    public string Encrypt(string str);
}