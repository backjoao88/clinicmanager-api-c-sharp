using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.Doctors.GetAll;

/// <summary>
/// Represents a query to retrieve all patients.
/// </summary>
public class GetAllDoctorsQuery : IRequest<List<DoctorViewModel>>;