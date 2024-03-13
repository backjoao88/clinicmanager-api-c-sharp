using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities;

/// <inheritdoc />
public class DoctorConfiguration : BaseConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Doctors");
        builder.Property(o => o.FirstName).IsRequired();
        builder.Property(o => o.LastName).IsRequired();
    }
}