using ClinicManager.Domain.Core.Integration;
using ClinicManager.Domain.Repositories.Contracts;

namespace ClinicManager.Domain.Repositories;

/// <summary>
/// Contract to a <see cref="Credential"/> data repository.
/// </summary>
public interface ICredentialRepository : IWritableRepository<Credential>, IReadableRepository<Credential>;