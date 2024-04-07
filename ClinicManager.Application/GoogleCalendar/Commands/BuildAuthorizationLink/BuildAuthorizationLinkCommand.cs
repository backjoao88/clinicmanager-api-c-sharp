using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.GoogleCalendar.Commands.BuildAuthorizationLink;

/// <summary>
/// Represents a command to build an authorization link.
/// </summary>
public class BuildAuthorizationLinkCommand : IRequest<string>;