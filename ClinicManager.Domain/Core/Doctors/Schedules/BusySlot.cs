namespace ClinicManager.Domain.Core.Doctors.Schedules;

/// <summary>
/// Represents a time slot.
/// </summary>
/// <param name="Start"></param>
/// <param name="End"></param>
public record BusySlot(TimeOnly Start, TimeOnly End);