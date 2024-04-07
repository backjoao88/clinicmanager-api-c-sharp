namespace ClinicManager.Application.Shared.Services.Email.Contracts;

/// <summary>
/// Provides an interface to generate ICS files.
/// </summary>
public interface IIcsProvider
{
    /// <summary>
    /// Generates the ICS file.
    /// </summary>
    /// <returns></returns>
    public Task<string> Generate(IcsMessage icsMessage);
}