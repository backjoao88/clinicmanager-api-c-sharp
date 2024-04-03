using ClinicManager.Application.Appointments.Services.Contracts;

namespace ClinicManager.Application.Appointments.Services;

/// <inheritdoc/>>
public class LinkProvider : ILinkProvider
{ 
    /// <inheritdoc/>>
    public Link GenerateConfirmationLink(string confirmationCode)
    {
        return new Link("localhost", "api/appointments/confirm", 5299, new Dictionary<string, string>()
        {
            { "code", confirmationCode}
        });
    }
    /// <inheritdoc/>>
    public Link GenerateCancelationLink(string confirmationCode)
    {
        return new Link("localhost", "api/appointments/cancel", 5499, new Dictionary<string, string>()
        {
            { "code", confirmationCode}
        });
    }
}