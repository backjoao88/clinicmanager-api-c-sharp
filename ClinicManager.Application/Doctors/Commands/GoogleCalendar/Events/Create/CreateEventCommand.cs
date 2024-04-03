using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Doctors.Commands.GoogleCalendar.Events.Create;

/// <summary>
/// Represents the command to create an event.
/// </summary>
public class CreateEventCommand : IRequest<Result>
{
    public CreateEventCommand(string token, string calendarId, string summary, string description, DateTime start, DateTime end)
    {
        Token = token;
        CalendarId = calendarId;
        Summary = summary;
        Description = description;
        Start = start;
        End = end;
    }
    public string Token { get; set; }
    public string CalendarId { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}