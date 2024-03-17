using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a doctor schedule.
/// </summary>
public class Schedule : Entity
{
    private List<ScheduleDay> _days = new();
    public List<ScheduleDay> Days
    {
        get => _days;
        private set => _days = value;
    }
}