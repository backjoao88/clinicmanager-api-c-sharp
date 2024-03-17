using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.GetById;

/// <summary>
/// Represents the <see cref="GetPatientByIdQuery"/> handler.
/// </summary>
public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<Patient>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Patient>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _unitOfWork.PatientRepository.ReadById(request.Id);
        if (patient is null)
        {
            return Result.Fail<Patient>(PatientDomainErrors.PatientNotFound);
        }
        return Result.Ok(patient);
    }
}