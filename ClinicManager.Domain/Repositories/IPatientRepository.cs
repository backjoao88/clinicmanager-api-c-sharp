using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

/// <summary>
/// Contract to a <see cref="Patient"/> data repository.
/// </summary>
public interface IPatientRepository : IWritableRepository<Patient>, IReadableRepository<Patient>,
    IReadableAllRepository<Patient>;