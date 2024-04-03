using System.Text;
using ClinicManager.Application.Shared.Email;
using ClinicManager.Application.Shared.Email.Contracts;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace ClinicManager.Infrastructure.Services.Email.Providers;

/// <inheritdoc/>>
public class IcsProvider : IIcsProvider
{
    /// <inheritdoc/>>
    public async Task<string> Generate(IcsMessage icsMessage)
    {
        var calendar = new Calendar();
        var calendarEvent = new CalendarEvent()
        {
            Attendees = new List<Attendee>()
            {
                new Attendee()
                {
                    Members = new List<string>()
                    {
                        ""
                    }
                }
            },
            Organizer = new Organizer("123"),
            Summary = icsMessage.Summary,
            Description = icsMessage.Description,
            Start = new CalDateTime(icsMessage.Day.Year, icsMessage.Day.Month, icsMessage.Day.Day, icsMessage.Start.Hour, icsMessage.Start.Minute, 00),
            End =  new CalDateTime(icsMessage.Day.Year, icsMessage.Day.Month, icsMessage.Day.Day, icsMessage.End.Hour, icsMessage.End.Minute, 00),
        };
        calendar.Events.Add(calendarEvent);
        return await Task.FromResult(new CalendarSerializer().SerializeToString(calendar));
    }
}