using System.Runtime.InteropServices.JavaScript;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a doctor schedule.
/// </summary>
public class Schedule : Entity
{
    public Schedule(Guid idDoctor)
    {
        Id = Guid.NewGuid();
        IdDoctor = idDoctor;
    }
    public Guid IdDoctor { get; private set; }
    private List<ScheduleDay> _days = new();
    public List<ScheduleDay> Days
    {
        get => _days;
        private set => _days = value;
    }

    /// <summary>
    /// Rollout a new schedule based on a number of days.
    /// </summary>
    /// <param name="futureDays"></param>
    public void Rollout(int futureDays)
    {
        _days = new();
        DateTime from = DateTime.Now;
        DateTime to = from.AddDays(futureDays);
        for (var index = from; index.Date < to; index = index.AddDays(1))
        {
            _days.Add(new(new DateOnly(index.Year, index.Month, index.Day), Id));
        }
    }
}