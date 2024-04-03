using ClinicManager.Application.Shared.GoogleCalendar;
using ClinicManager.Application.Shared.GoogleCalendar.Dtos;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Doctors.Commands.GoogleCalendar.Events.Create;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Result>
{
    private readonly IGoogleCalendarService _googleCalendarService;

    public CreateEventCommandHandler(IGoogleCalendarService googleCalendarService)
    {
        _googleCalendarService = googleCalendarService;
    }

    public async Task<Result> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var googleCalendarAuthenticationResponse = await _googleCalendarService.CreateEvent(new GoogleCalendarEventRequest(
            request.Token,
            request.CalendarId,
            request.Summary,
            request.Description,
            request.Start,
            request.End
        ));
        return Result.Ok(googleCalendarAuthenticationResponse);
    }
}