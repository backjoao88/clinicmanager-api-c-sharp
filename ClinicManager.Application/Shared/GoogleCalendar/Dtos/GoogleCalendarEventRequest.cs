namespace ClinicManager.Application.Shared.GoogleCalendar.Dtos;

/// <summary>
/// Request to create an event by using the Google Calendar API.
/// </summary>
/// <param name="Token"></param>
/// <param name="Summary"></param>
/// <param name="Description"></param>
/// <param name="Start"></param>
/// <param name="End"></param>
public record GoogleCalendarEventRequest(string Token, string CalendarId, string Summary, string Description, DateTime Start, DateTime End);