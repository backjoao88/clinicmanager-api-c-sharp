using ClinicManager.Api.Abstractions;
using ClinicManager.Application.Appointments.Commands.Schedule;
using ClinicManager.Application.Appointments.Queries.GetByDoctor;
using ClinicManager.Domain.Primitives;
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

    /// <summary>
    /// Endpoint to retrieve all appointments from a doctor.
    /// </summary>
    [HttpGet("{idDoctor}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAppointmentsByDoctor(Guid idDoctor, [FromBody] GetAppointmentsByDoctorQuery getAppointmentsByDoctorQuery)
    {
        getAppointmentsByDoctorQuery.IdDoctor = idDoctor;
        var appointments = await _mediator.Send(getAppointmentsByDoctorQuery);
        return Ok(appointments);
    }
    
}