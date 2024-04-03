using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Doctors.Commands.Create;

/// <summary>
/// Represents the <see cref="CreateDoctorCommand"/> handler.
/// </summary>
public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Result>
{
    private IUnitOfWork _unitOfWork;

    public CreateDoctorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor(request.FirstName, request.LastName);
        await _unitOfWork.DoctorRepository.Add(doctor);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}