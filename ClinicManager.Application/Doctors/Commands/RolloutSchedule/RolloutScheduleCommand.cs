using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Commands.Doctors.RolloutSchedule;

/// <summary>
/// Represents the create schedule command.
/// </summary>
public class RolloutScheduleCommand : IRequest<Result>
{
    public RolloutScheduleCommand(Guid idDoctor, int futureDays)
    {
        IdDoctor = idDoctor;
        FutureDays = futureDays;
    }
    public Guid IdDoctor { get; set; }
    public int FutureDays { get; set; }
}