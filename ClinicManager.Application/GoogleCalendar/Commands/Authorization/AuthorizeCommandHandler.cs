using ClinicManager.Application.GoogleCalendar.Authorize;
using ClinicManager.Application.Shared.Services.GoogleCalendar;
using ClinicManager.Domain.Core.Integration;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.GoogleCalendar.Commands.Authorization;

/// <summary>
/// Represents the <see cref="AuthorizeCommand"/> handler.
/// </summary>
public class AuthorizeCommandHandler : IRequestHandler<AuthorizeCommand, Result>
{
    private readonly IGoogleCalendarService _googleCalendarService;
    private readonly IUnitOfWork _unitOfWork;    
    
    public AuthorizeCommandHandler(IGoogleCalendarService googleCalendarService, IUnitOfWork unitOfWork)
    {
        _googleCalendarService = googleCalendarService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
    {
        var googleCredentialsResponse = await _googleCalendarService.HandleAuthorizationCode(request.Code);
        await _unitOfWork.CredentialRepository.Add(new Credential(
            googleCredentialsResponse.Issuer,
            googleCredentialsResponse.AccessToken,
            googleCredentialsResponse.RefreshToken,
            googleCredentialsResponse.Expiration
        ));
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}