using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Patients.Commands.Create;

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
        var patient = new Patient(request.FirstName, request.LastName, request.Email);
        await _unitOfWork.PatientRepository.Add(patient);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}