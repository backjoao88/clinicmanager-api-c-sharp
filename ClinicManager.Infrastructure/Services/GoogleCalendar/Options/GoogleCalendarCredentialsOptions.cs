namespace ClinicManager.Infrastructure.Services.GoogleCalendar.Options;

public class GoogleCalendarCredentialsOptions
{
    public string ApplicationName { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string AuthUri { get; set; } = string.Empty;
    public string TokenUri { get; set; } = string.Empty;
    public string RedirectUri { get; set; } = string.Empty;
}