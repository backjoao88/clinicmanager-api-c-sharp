using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Core.Doctors.Specialities;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

/// <summary>
/// Contract to a <see cref="Patient"/> data repository.
/// </summary>
public interface IDoctorRepository : IWritableRepository<Doctor>, IReadableRepository<Doctor>,
    IReadableAllRepository<Doctor>
{
    /// <summary>
    /// Adds a new schedule to a doctor.
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    public Task AddSchedule(Schedule schedule);
    /// <summary>
    /// Adds a busy slot to a doctor.
    /// </summary>
    /// <param name="busySlot"></param>
    /// <returns></returns>
    public Task AddBusySlot(BusySlot busySlot);
    /// <summary>
    /// Reads an available schedule day of a doctor.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public Task<ScheduleDay?> ReadScheduleDay(DateOnly date);
    /// <summary>
    /// Reads a doctor speciality by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Speciality?> ReadSpecialityById(Guid id);
}