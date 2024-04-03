using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a day in a doctor schedule.
/// </summary>
public class ScheduleDay : Entity
{
    public ScheduleDay(DateOnly day, Guid idSchedule)
    {
        Id = Guid.NewGuid();
        Day = day;
        IdSchedule = idSchedule;
        DayStart = new TimeOnly(08, 00, 00);
        DayEnd = new TimeOnly(17, 00, 00);
    }
    public Guid IdSchedule { get; private set; }
    public DateOnly Day { get; private set; }
    public TimeOnly DayStart { get; }
    public TimeOnly DayEnd { get; }
    private List<BusySlot> _busySlots = new();
    public List<BusySlot> BusySlots
    {
        get => _busySlots;
        private set => _busySlots = value;
    }

    /// <summary>
    /// Adds a busy slot in the doctor schedule.
    /// </summary>
    /// <param name="busySlot"></param>
    /// <returns></returns>
    public Task AddBusySlot(BusySlot busySlot)
    {
        _busySlots.Add(busySlot);
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