using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.GoogleCalendar.Authorize;

/// <summary>
/// Represents a code to handle t
/// </summary>
public class AuthorizeCommand : IRequest<Result>
{
    public AuthorizeCommand(string userId, string code)
    {
        UserId = userId;
        Code = code;
    }
    public string UserId { get; set; }
    public string Code { get; set; }
}