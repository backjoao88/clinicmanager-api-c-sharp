using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Patient;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Commands.Patients.Create;

/// <summary>
/// Represents the <see cref="CreatePatientCommand"/> handler.
/// </summary>
public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result>
{
    private IUnitOfWork _unitOfWork;

    public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Patient(request.FirstName, request.LastName);
        await _unitOfWork.PatientRepository.Add(patient);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}