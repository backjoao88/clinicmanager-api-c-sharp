using ClinicManager.Application.Patients.Views;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.GetAll;

/// <summary>
/// Represents a query to retrieve all patients.
/// </summary>
public class GetAllPatientsQuery : IRequest<List<PatientViewModel>>;