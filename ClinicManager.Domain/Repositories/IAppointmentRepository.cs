using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

public interface IAppointmentRepository : IWritableRepository<Appointment>, IReadableRepository<Appointment>,
    IReadableAllRepository<Appointment>
{
    /// <summary>
    /// Reads all appointments by a given doctor.
    /// </summary>
    /// <param name="idDoctor"></param>
    /// <returns></returns>
    public Task<List<Appointment>> ReadByDoctor(Guid idDoctor);
    /// <summary>
    /// Reads an appointment by a given token.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<Appointment?> ReadByCode(Guid token);
}