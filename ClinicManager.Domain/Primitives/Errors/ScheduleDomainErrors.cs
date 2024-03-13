namespace ClinicManager.Domain.Primitives.Errors;

public class ScheduleDomainErrors
{
    public static Error AlreadyScheduled => new("Schedule.AlreadyScheduled", "Start date is already scheduled.");
}