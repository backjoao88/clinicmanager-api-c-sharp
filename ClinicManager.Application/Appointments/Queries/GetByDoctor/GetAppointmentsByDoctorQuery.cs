using ClinicManager.Application.Appointments.Views;
using MediatR;

namespace ClinicManager.Application.Appointments.Queries.GetByDoctor;

/// <summary>
/// Represents a query to retrieve all appointments by doctor.
/// </summary>
public class GetAppointmentsByDoctorQuery : IRequest<List<DoctorAppointmentViewModel>>
{
    public GetAppointmentsByDoctorQuery(Guid idDoctor)
    {
        IdDoctor = idDoctor;
    }
    public Guid IdDoctor { get; set; }
}