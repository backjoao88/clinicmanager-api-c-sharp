namespace ClinicManager.Application.Shared.GoogleCalendar.Dtos;

/// <summary>
/// Response from the event creation of the Google Calendar API.
/// </summary>
/// <param name="Summary"></param>
/// <param name="Description"></param>
public record GoogleCalendarEventResponse(string Summary, string Description);