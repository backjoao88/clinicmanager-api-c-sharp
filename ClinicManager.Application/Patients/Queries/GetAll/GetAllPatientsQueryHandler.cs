using ClinicManager.Application.Patients.Views;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.GetAll;

/// <summary>
/// Represents the command to query all patients.
/// </summary>
public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPatientsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PatientViewModel>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _unitOfWork
            .PatientRepository
            .ReadAll();
        var patientsViewModel = patients
            .Select(o => new PatientViewModel(o.Id, o.FirstName, o.LastName))
            .ToList();
        return patientsViewModel;
    }
}