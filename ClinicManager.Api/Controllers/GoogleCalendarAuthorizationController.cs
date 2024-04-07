using ClinicManager.Application.GoogleCalendar.Authorize;
using ClinicManager.Application.GoogleCalendar.Commands.BuildAuthorizationLink;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    
    /// <summary>
    /// Endpoint used to exchanges the authorization code for the access token.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [HttpGet("authorize")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthorizationCode([FromQuery] string code)
    {
        await _mediator.Send(new AuthorizeCommand(code));
        return Ok();
    }

    /// <summary>
    /// Endpoint used to retrieve the authorization link.
    /// </summary>
    /// <returns></returns>
    [HttpGet("authorize-link")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthorizationLink()
    {
        var result = await _mediator.Send(new BuildAuthorizationLinkCommand());
        return Ok(new
        {
            Link = result
        });
    }
    
}