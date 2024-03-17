using ClinicManager.Application.ViewModels;
using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Queries.Doctors.GetById;

/// <summary>
/// Represents a query to return a patient by id.
/// </summary>
public class GetDoctorByIdQuery : IRequest<Result<DoctorViewModel>>
{
    public Guid Id { get; set; } = Guid.Empty;
}