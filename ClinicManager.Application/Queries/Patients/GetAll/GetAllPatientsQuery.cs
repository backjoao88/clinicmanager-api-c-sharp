using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.Patients.GetAll;

/// <summary>
/// Represents a query to retrieve all patients.
/// </summary>
public class GetAllPatientsQuery : IRequest<List<PatientViewModel>>;