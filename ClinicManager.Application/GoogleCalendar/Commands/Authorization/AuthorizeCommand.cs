using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.GoogleCalendar.Authorize;

/// <summary>
/// Represents a code to handle t
/// </summary>
public class AuthorizeCommand : IRequest<Result>
{
    public AuthorizeCommand(string code)
    {
        Code = code;
    }
    public string Code { get; set; }
}