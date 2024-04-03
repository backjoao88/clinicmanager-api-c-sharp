using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Doctors.Commands.RolloutSchedule;

/// <summary>
/// Represents the <see cref="RolloutScheduleCommand"/> handler.
/// </summary>
public class RolloutScheduleCommandHandler : IRequestHandler<RolloutScheduleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RolloutScheduleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RolloutScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = new Schedule(request.IdDoctor);
        schedule.Rollout(request.FutureDays);
        await _unitOfWork.DoctorRepository.AddSchedule(schedule);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}