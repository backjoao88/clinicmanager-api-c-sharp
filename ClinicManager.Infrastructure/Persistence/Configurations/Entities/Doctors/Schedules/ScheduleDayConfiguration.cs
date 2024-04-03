using ClinicManager.Domain.Core.Doctors.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Doctors.Schedules;

public class ScheduleDayConfiguration : BaseConfiguration<ScheduleDay>
{
    public override void Configure(EntityTypeBuilder<ScheduleDay> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_ScheduleDay");
        builder.OwnsMany(o => o.BusySlots, options =>
        {
            options.ToTable("tbl_BusySlots");
            options.Property(o => o.Start).IsRequired();
            options.Property(o => o.End).IsRequired();
        });
    }  
}