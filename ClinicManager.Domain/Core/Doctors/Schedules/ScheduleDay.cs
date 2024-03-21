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
        DayStart = new TimeOnly(08, 00, 00);
        DayEnd = new TimeOnly(17, 00, 00);
    }
    public Guid IdSchedule { get; private set; }
    public DateOnly Day { get; private set; }
    public TimeOnly DayStart { get; }
    public TimeOnly DayEnd { get; }
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

    /// <summary>
    /// Checks if a range of dates is between a scheduled busy slot.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public bool IsBusy(TimeOnly start, TimeOnly end)
    {
        if (!_busySlots.Any()) return false;
        foreach (var slot in this._busySlots)
        {
            var isStartBetweenInterval = start.IsBetween(slot.Start, slot.End);
            var isEndBetweenInterval = end.IsBetween(slot.Start, slot.End);
            if (isStartBetweenInterval || isEndBetweenInterval)
            {
                return true;
            }
        }
        return false;
    }
}