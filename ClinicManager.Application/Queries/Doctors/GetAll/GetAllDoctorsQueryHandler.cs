using ClinicManager.Application.Queries.Patients.GetAll;
using ClinicManager.Application.ViewModels;
using ClinicManager.Domain.Core;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Queries.Doctors.GetAll;

/// <summary>
/// Represents the command to query all patients.
/// </summary>
public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DoctorViewModel>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _unitOfWork.DoctorRepository.ReadAll();
        var doctorsViewModels = doctors
            .Select(o => new DoctorViewModel(o.Id, o.FirstName, o.LastName))
            .ToList();
        return doctorsViewModels;
    }
}