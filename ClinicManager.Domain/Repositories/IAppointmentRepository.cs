using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

public interface IAppointmentRepository : IWritableRepository<Appointment>, IReadableRepository<Appointment>,
    IReadableAllRepository<Appointment>
{
    /// <summary>
    /// Reads all appointments from a doctor.
    /// </summary>
    /// <param name="idDoctor"></param>
    /// <returns></returns>
    public Task<List<Appointment>> ReadByDoctor(Guid idDoctor);
}