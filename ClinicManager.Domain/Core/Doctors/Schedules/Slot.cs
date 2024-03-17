namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a time slot.
/// </summary>
/// <param name="Day"></param>
/// <param name="Start"></param>
/// <param name="End"></param>
public record Slot(DateOnly Day, Guid IdScheduleDay, DateTime Start, DateTime End);