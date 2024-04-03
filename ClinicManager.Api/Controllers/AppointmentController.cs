using ClinicManager.Api.Abstractions;
using ClinicManager.Api.Attributes;
using ClinicManager.Application.Appointments.Commands.Cancel;
using ClinicManager.Application.Appointments.Commands.Confirm;
using ClinicManager.Application.Appointments.Commands.Schedule;
using ClinicManager.Application.Appointments.Queries.GetByDoctor;
using ClinicManager.Domain.Core.Users.Enumerations;
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
    /// Endpoint to confirm an appointment.
    /// </summary>
    /// <param name="code"></param>
    [HttpPost("confirm")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Confirm([FromQuery] Guid code)
    {
        var result = await _mediator.Send(new ConfirmAppointmentCommand(code));
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Endpoint to cancel an appointment.
    /// </summary>
    /// <param name="code"></param>
    [HttpPost("cancel")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Cancel([FromQuery] Guid code)
    {
        var result = await _mediator.Send(new CancelAppointmentCommand(code));
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint to schedule an appointment.
    /// </summary>
    /// <param name="scheduleAppointmentCommand"></param>
    [HttpPost]
    [HasPermission(ERole.Admin, ERole.Patient)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Schedule([FromBody] ScheduleAppointmentCommand scheduleAppointmentCommand)
    { 
        var result = await _mediator.Send(scheduleAppointmentCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint to retrieve all appointments from a doctor.
    /// </summary>
    [HttpGet("{idDoctor}")]
    [HasPermission(ERole.Admin, ERole.Doctor, ERole.Patient)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAppointmentsByDoctor(Guid idDoctor, [FromBody] GetAppointmentsByDoctorQuery getAppointmentsByDoctorQuery)
    {
        getAppointmentsByDoctorQuery.IdDoctor = idDoctor;
        var appointments = await _mediator.Send(getAppointmentsByDoctorQuery);
        return Ok(appointments);
    }
    
}