using ClinicManager.Api.Abstractions;
using ClinicManager.Api.Attributes;
using ClinicManager.Application.Doctors.Commands.Create;
using ClinicManager.Application.Doctors.Commands.RolloutSchedule;
using ClinicManager.Application.Doctors.Queries.GetAll;
using ClinicManager.Application.Doctors.Queries.GetById;
using ClinicManager.Domain.Core.Users.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers;

[ApiController]
[Route("/api/doctors")]
public class DoctorController : ApiController
{
    private readonly IMediator _mediator;
    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to save a new patient.
    /// </summary>
    /// <param name="createDoctorCommand"></param>
    [HttpPost]
    [HasPermission(ERole.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreateDoctorCommand createDoctorCommand)
    { 
        var result = await _mediator.Send(createDoctorCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Endpoint to get a doctor by id.
    /// </summary>
    [HttpGet("{id}")]
    [HasPermission(ERole.Admin, ERole.Doctor, ERole.Patient)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getDoctorByIdQuery = new GetDoctorByIdQuery();
        getDoctorByIdQuery.Id = id;
        var result = await _mediator.Send(getDoctorByIdQuery);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
    
    /// <summary>
    /// Endpoint to retrieve all doctors.
    /// </summary>
    [HttpGet]
    [HasPermission(ERole.Admin, ERole.Doctor, ERole.Patient)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    { 
        var doctors = await _mediator.Send(new GetAllDoctorsQuery());
        return Ok(doctors);
    }
    
    /// <summary>
    /// Endpoint to rollout a new schedule.
    /// </summary>
    [HttpPost("{idDoctor}/schedules")]
    [HasPermission(ERole.Admin, ERole.Doctor)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RolloutSchedule(Guid idDoctor, [FromBody] RolloutScheduleCommand rolloutScheduleCommand)
    {
        rolloutScheduleCommand.IdDoctor = idDoctor;
        var result = await _mediator.Send(rolloutScheduleCommand);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }
}