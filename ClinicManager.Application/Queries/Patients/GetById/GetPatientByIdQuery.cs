using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Patient;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Queries.Patients.GetById;

/// <summary>
/// Represents a query to return a patient by id.
/// </summary>
public class GetPatientByIdQuery : IRequest<Result<Patient>>
{
    public Guid Id { get; set; } = Guid.Empty;
}