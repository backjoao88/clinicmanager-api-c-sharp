using ClinicManager.Application.Doctors.Views;
using ClinicManager.Domain.Core.Doctors.Enumerations;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Doctors.Queries.GetAll;

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
            .Select(o => new DoctorViewModel(o.Id, o.FirstName, o.LastName, o.Speciality.SpecialityArea))
            .ToList();
        return doctorsViewModels;
    }
}