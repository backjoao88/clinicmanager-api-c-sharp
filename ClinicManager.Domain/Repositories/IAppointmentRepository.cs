using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

public interface IAppointmentRepository : IWritableRepository<Appointment>, IReadableRepository<Appointment>;