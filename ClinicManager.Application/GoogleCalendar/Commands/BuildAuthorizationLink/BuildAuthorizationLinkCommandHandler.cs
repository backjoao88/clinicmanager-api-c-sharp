using ClinicManager.Application.Shared.Services.GoogleCalendar;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.GoogleCalendar.Commands.BuildAuthorizationLink;

public class BuildAuthorizationLinkCommandHandler : IRequestHandler<BuildAuthorizationLinkCommand, string>
{
    private readonly IGoogleCalendarService _googleCalendarService;

    public BuildAuthorizationLinkCommandHandler(IGoogleCalendarService googleCalendarService)
    {
        _googleCalendarService = googleCalendarService;
    }

    public Task<string> Handle(BuildAuthorizationLinkCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_googleCalendarService.BuildAuthorizationLink());
    }
}