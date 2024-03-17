using ClinicManager.Domain.Core.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Doctors;

/// <inheritdoc />
public class DoctorConfiguration : BaseConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Doctors");
        builder.HasOne(o => o.Schedule).WithOne().IsRequired().HasForeignKey<Doctor>(o => o.IdSchedule)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(o => o.FirstName).IsRequired();
        builder.Property(o => o.LastName).IsRequired();
    }
}