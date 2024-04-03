using ClinicManager.Application.GoogleCalendar.Authorize;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ClinicManager.Api.Controllers;

[ApiController]
[Route("/api/googlecalendar")]
public class GoogleCalendarAuthorizationController : ControllerBase
{
    private IMediator _mediator;

    public GoogleCalendarAuthorizationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("authorize")]
    public async Task<IActionResult> GetAuthorizationCode([FromQuery] string code)
    {
        var result = await _mediator.Send(new AuthorizeCommand("", code));
        return Ok();
    }
}