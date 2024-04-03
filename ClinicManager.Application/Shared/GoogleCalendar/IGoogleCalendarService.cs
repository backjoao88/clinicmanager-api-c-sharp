using ClinicManager.Application.Shared.GoogleCalendar.Dtos;

namespace ClinicManager.Application.Shared.GoogleCalendar;

public interface IGoogleCalendarService
{
    /// <summary>
    /// Handles the authorization code from the client.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<GoogleCalendarCredentialsResponse> HandleAuthorizationCode(string code);
    /// <summary>
    /// Creates an event in the specified calendar.
    /// </summary>
    /// <returns>A <see cref="GoogleCalendarEventResponse"/> response.</returns>
    public Task<GoogleCalendarEventResponse> CreateEvent(GoogleCalendarEventRequest googleCalendarEventRequest);
}