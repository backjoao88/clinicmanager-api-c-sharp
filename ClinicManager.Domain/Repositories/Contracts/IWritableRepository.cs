using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Repositories.Contracts;

public interface IWritableRepository<in TEntity> where TEntity : Entity
{
    /// <summary>
    /// Adds an entity to a data repository.
    /// </summary>
    /// <param name="entity"></param>
    public Task Add(TEntity entity);
}