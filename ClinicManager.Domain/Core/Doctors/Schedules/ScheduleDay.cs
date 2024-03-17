using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a day in a doctor schedule.
/// </summary>
public class ScheduleDay : Entity
{
    public ScheduleDay(DateOnly day, Guid idSchedule)
    {
        Day = day;
        IdSchedule = idSchedule;
        Start = new TimeOnly(08, 00, 00);
        End = new TimeOnly(17, 00, 00);
    }
    public Guid IdSchedule { get; private set; }
    public DateOnly Day { get; private set; }
    public TimeOnly Start { get; }
    public TimeOnly End { get; }
    private List<Slot> _busySlots = new();
    public List<Slot> BusySlots
    {
        get => _busySlots;
        private set => _busySlots = value;
    }

    /// <summary>
    /// Adds a busy slot in the doctor schedule.
    /// </summary>
    /// <param name="slot"></param>
    /// <returns></returns>
    public Task AddBusySlot(Slot slot)
    {
        _busySlots.Add(slot);
        return Task.CompletedTask;
    }
}