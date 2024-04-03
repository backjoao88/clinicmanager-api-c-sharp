using ClinicManager.Application.Shared.Authentication;
using ClinicManager.Application.Users.Views;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Users.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    
    public LoginUserCommandHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<Result<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _jwtService.Encrypt(request.Password);
        var matchedUser = await _unitOfWork.UserRepository.MatchEmailAndPassword(request.Email, passwordHash);
        if (matchedUser is null)
        {
            return Result.Fail<LoginViewModel>(UserDomainErrors.UserInvalidCredentials);
        }
        var token = _jwtService.GenerateAuthenticationToken(matchedUser.Id, matchedUser.Role);
        return Result.Ok(new LoginViewModel(token));
    }
}