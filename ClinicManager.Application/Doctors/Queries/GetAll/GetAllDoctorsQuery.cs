using ClinicManager.Application.Doctors.Views;
using MediatR;

namespace ClinicManager.Application.Doctors.Queries.GetAll;

/// <summary>
/// Represents a query to retrieve all patients.
/// </summary>
public class GetAllDoctorsQuery : IRequest<List<DoctorViewModel>>;