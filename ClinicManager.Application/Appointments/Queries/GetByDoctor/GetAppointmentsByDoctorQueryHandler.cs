using ClinicManager.Application.Appointments.Views;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Appointments.Queries.GetByDoctor;

/// <summary>
/// Represents the <see cref="GetAppointmentsByDoctorQuery"/> handler.
/// </summary>
public class GetAppointmentsByDoctorQueryHandler : IRequestHandler<GetAppointmentsByDoctorQuery, List<DoctorAppointmentViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAppointmentsByDoctorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DoctorAppointmentViewModel>> Handle(GetAppointmentsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _unitOfWork.AppointmentRepository.ReadByDoctor(request.IdDoctor);
        var appointmentsViewModel = appointments
            .Select(o => new DoctorAppointmentViewModel(o.IdPatient, o.Start, o.End, o.Status))
            .ToList();
        return appointmentsViewModel;
    }
}