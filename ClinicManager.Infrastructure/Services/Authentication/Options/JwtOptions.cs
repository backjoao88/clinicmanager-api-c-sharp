namespace ClinicManager.Infrastructure.Services.Authentication.Options;

/// <summary>
/// Represents a JWT token options.
/// </summary>
public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string PrivateKey { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}