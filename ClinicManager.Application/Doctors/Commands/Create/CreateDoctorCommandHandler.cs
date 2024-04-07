using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
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
        var speciality = await _unitOfWork.DoctorRepository.ReadSpecialityById(request.IdSpeciality);
        if (speciality is null)
        {
            return Result.Fail(DoctorDomainErrors.DoctorSpecialityNotAvailable);
        }
        var doctor = new Doctor(request.FirstName, request.LastName, request.Email, request.IdSpeciality);
        await _unitOfWork.DoctorRepository.Add(doctor);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}