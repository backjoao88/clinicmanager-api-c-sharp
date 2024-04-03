using System.ComponentModel.DataAnnotations.Schema;
using ClinicManager.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities;

/// <summary>
/// Entity configuration for the database.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .ValueGeneratedNever();
        builder.Ignore(o => o.Events);
    }
}