using ClinicManager.Api.Abstractions;
using ClinicManager.Api.Attributes;
using ClinicManager.Application.Users.Commands.Create;
using ClinicManager.Application.Users.Commands.Login;
using ClinicManager.Domain.Core.Users.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Api.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to save a new patient.
    /// </summary>
    /// <param name="createUserCommand"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
    { 
        var result = await _mediator.Send(createUserCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Endpoint to login into the system.
    /// </summary>
    [HttpPut("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var result = await _mediator.Send(loginUserCommand);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}