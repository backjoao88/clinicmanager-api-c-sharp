using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Integration;

/// <summary>
/// Represents a third-party access credentials.
/// </summary>
public class Credential : Entity
{
    public Credential(string issuer, string accessToken, string refreshToken, DateTime expiresIn)
    {
        Id = Guid.NewGuid();
        Issuer = issuer;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }
    public string Issuer { get; private set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}