using ClinicManager.Api.Abstractions;
using ClinicManager.Application.Commands.Patients.Create;
using ClinicManager.Application.Queries.Patients.GetAll;
using ClinicManager.Application.Queries.Patients.GetById;
using MediatR;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    { 
        var patients = await _mediator.Send(new GetAllPatientsQuery());
        return Ok(patients);
    }
}