using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Core.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Appointments;

/// <inheritdoc />
public class AppointmentCodesConfiguration : BaseConfiguration<AppointmentCode>
{
    public override void Configure(EntityTypeBuilder<AppointmentCode> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_AppointmentCodes");
        builder.Property(o => o.IdAppointment).IsRequired();
        builder.Property(o => o.Code).IsRequired();
        builder.Property(o => o.Expiration).IsRequired();
    }   
}