namespace ClinicManager.Infrastructure.Services.Email.Options;

/// <summary>
/// Represents the e-mail options.
/// </summary>
public class EmailOptions
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}