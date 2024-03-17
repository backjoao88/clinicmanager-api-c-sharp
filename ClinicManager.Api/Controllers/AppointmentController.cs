using ClinicManager.Api.Abstractions;
using ClinicManager.Application.Commands.Appointments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers;

[ApiController]
[Route("/api/appointments")]
public class AppointmentController : ApiController
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to schedule an appointment.
    /// </summary>
    /// <param name="scheduleAppointmentCommand"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Schedule([FromBody] ScheduleAppointmentCommand scheduleAppointmentCommand)
    { 
        var result = await _mediator.Send(scheduleAppointmentCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
}