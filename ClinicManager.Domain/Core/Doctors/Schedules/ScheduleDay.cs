using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a day in a doctor schedule.
/// </summary>
public class ScheduleDay : Entity
{
    public Guid IdSchedule { get; private set; }
    private List<Slot> _busySlots = new();
    public List<Slot> BusySlots
    {
        get => _busySlots;
        private set => _busySlots = value;
    }
}