using ClinicManager.Application.ViewModels;
using ClinicManager.Domain.Core;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Queries.Doctors.GetById;

/// <summary>
/// Represents the <see cref="GetDoctorByIdQuery"/> handler.
/// </summary>
public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Result<DoctorViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDoctorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DoctorViewModel>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorRepository.ReadById(request.Id);
        if (doctor is null)
        {
            return Result.Fail<DoctorViewModel>(DoctorDomainErrors.DoctorNotFound);
        }
        var doctorViewModel = new DoctorViewModel(doctor.Id, doctor.FirstName, doctor.LastName);
        return Result.Ok(doctorViewModel);
    }
}