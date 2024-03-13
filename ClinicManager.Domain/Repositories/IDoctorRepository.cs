using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Patient;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

/// <summary>
/// Contract to a <see cref="Patient"/> data repository.
/// </summary>
public interface IDoctorRepository : IWritableRepository<Doctor>, IReadableRepository<Doctor>,
    IReadableAllRepository<Doctor>;