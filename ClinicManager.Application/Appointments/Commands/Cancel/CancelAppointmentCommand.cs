using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Appointments.Commands.Cancel;

/// <summary>
/// Command to confirm an appointment.
/// </summary>
public class CancelAppointmentCommand : IRequest<Result>
{
    public CancelAppointmentCommand(Guid code)
    {
        Code = code;
    }
    public Guid Code { get; set; }
}