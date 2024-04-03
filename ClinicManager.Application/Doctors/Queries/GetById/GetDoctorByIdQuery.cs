using ClinicManager.Application.Doctors.Views;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Doctors.Queries.GetById;

/// <summary>
/// Represents a query to return a patient by id.
/// </summary>
public class GetDoctorByIdQuery : IRequest<Result<DoctorViewModel>>
{
    public Guid Id { get; set; } = Guid.Empty;
}