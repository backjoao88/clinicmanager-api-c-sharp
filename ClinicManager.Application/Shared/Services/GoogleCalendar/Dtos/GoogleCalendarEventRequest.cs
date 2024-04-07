namespace ClinicManager.Application.Shared.Services.GoogleCalendar.Dtos;

/// <summary>
/// Request to create an event by using the Google Calendar API.
/// </summary>
/// <param name="AccessToken"></param>
/// <param name="Summary"></param>
/// <param name="Description"></param>
/// <param name="Start"></param>
/// <param name="End"></param>
public record GoogleCalendarEventRequest(string AccessToken, string CalendarId, string Summary, string Description, string[] Attendees, DateTime Start, DateTime End);