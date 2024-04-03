using ClinicManager.Domain.Core.Doctors.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Doctors.Schedules;

public class ScheduleConfiguration : BaseConfiguration<Schedule>
{
    public override void Configure(EntityTypeBuilder<Schedule> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Schedules");
        builder.HasMany(o => o.Days).WithOne().HasForeignKey(o => o.IdSchedule)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);
    }   
}