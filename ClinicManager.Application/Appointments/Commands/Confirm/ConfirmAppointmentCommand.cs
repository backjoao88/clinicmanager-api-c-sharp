using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Appointments.Commands.Confirm;

/// <summary>
/// Command to confirm an appointment.
/// </summary>
public class ConfirmAppointmentCommand : IRequest<Result>
{
    public ConfirmAppointmentCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}