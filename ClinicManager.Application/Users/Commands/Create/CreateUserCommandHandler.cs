using ClinicManager.Application.Shared.Authentication;
using ClinicManager.Domain.Core.Users;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Users.Commands.Create;

/// <summary>
/// Represents the <see cref="CreateUserCommand"/> handler.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isEmailUnique = await _unitOfWork.UserRepository.IsEmailUnique(request.Email);
        if (!isEmailUnique)
        {
            return Result.Fail(UserDomainErrors.UserEmailAlreadyExists);
        }
        var passwordHash = _jwtService.Encrypt(request.Password);
        var user = new User(request.Email, passwordHash, request.Role);
        await _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}