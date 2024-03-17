using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.GetById;

/// <summary>
/// Represents a query to return a patient by id.
/// </summary>
public class GetPatientByIdQuery : IRequest<Result<Patient>>
{
    public Guid Id { get; set; } = Guid.Empty;
}