using ClinicManager.Api.Abstractions;
using ClinicManager.Api.Attributes;
using ClinicManager.Application.Patients.Commands.Create;
using ClinicManager.Application.Patients.Queries.GetAll;
using ClinicManager.Application.Patients.Queries.GetById;
using ClinicManager.Domain.Core.Users.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers;

[ApiController]
[Route("/api/patients")]
public class PatientController : ApiController
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to save a new patient.
    /// </summary>
    /// <param name="createPatientCommand"></param>
    [HttpPost]
    [HasPermission(ERole.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreatePatientCommand createPatientCommand)
    { 
        var result = await _mediator.Send(createPatientCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Endpoint to get a patient by id.
    /// </summary>
    [HttpGet("{id}")]
    [HasPermission(ERole.Admin, ERole.Doctor, ERole.Patient)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getPatientByIdQuery = new GetPatientByIdQuery();
        getPatientByIdQuery.Id = id;
        var result = await _mediator.Send(getPatientByIdQuery);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
    
    /// <summary>
    /// Endpoint to save a new patient.
    /// </summary>
    [HttpGet]
    [HasPermission(ERole.Admin, ERole.Doctor, ERole.Patient)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    { 
        var patients = await _mediator.Send(new GetAllPatientsQuery());
        return Ok(patients);
    }
}