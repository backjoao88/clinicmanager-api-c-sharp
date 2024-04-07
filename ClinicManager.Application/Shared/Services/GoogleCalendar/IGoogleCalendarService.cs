using ClinicManager.Application.Shared.Services.GoogleCalendar.Dtos;

namespace ClinicManager.Application.Shared.Services.GoogleCalendar;

public interface IGoogleCalendarService
{
    /// <summary>
    /// Handles the authorization code from the client.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<GoogleCalendarCredentialsResponse> HandleAuthorizationCode(string code);
    /// <summary>
    /// Builds an authorization link for the client.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string BuildAuthorizationLink();
    /// <summary>
    /// Creates an event in the specified calendar.
    /// </summary>
    /// <returns>A <see cref="GoogleCalendarEventResponse"/> response.</returns>
    public Task<GoogleCalendarEventResponse> CreateEvent(GoogleCalendarEventRequest googleCalendarEventRequest);
    /// <summary>
    /// Creates an event in the specified calendar.
    /// </summary>
    /// <returns>A <see cref="GoogleCalendarEventResponse"/> response.</returns>
    public Task<GoogleCalendarCredentialsResponse> RefreshToken(string refreshToken);
}