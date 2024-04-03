using ClinicManager.Domain.Core.Appointments.Events;
using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Primitives.Contracts;
using ClinicManager.Domain.Repositories;

namespace ClinicManager.Application.Doctors.Events;

/// <summary>
/// Represents one of the <see cref="AppointmentScheduledDomainEvent"/> handlers.
/// </summary>
public class AddBusySlotEventHandler : IDomainEventHandler<AppointmentScheduledDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork; 

    public AddBusySlotEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AppointmentScheduledDomainEvent notification, CancellationToken cancellationToken)
    {
        var scheduleDay  = await _unitOfWork.DoctorRepository.ReadScheduleDay(notification.Day);
        if (scheduleDay is null) return;
        var slot = new BusySlot(notification.Start, notification.End);
        await scheduleDay.AddBusySlot(slot);
    }
}