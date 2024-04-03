using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

/// <summary>
/// Contract to a <see cref="Patient"/> data repository.
/// </summary>
public interface IDoctorRepository : IWritableRepository<Doctor>, IReadableRepository<Doctor>,
    IReadableAllRepository<Doctor>
{
    public Task AddSchedule(Schedule schedule);
    public Task AddBusySlot(BusySlot busySlot);
    public Task<ScheduleDay?> ReadScheduleDay(DateOnly date);
}