using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Core.Appointments.Enumerations;
using ClinicManager.Domain.Core.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Appointments;

/// <inheriteddoc/>
public class AppointmentConfiguration : BaseConfiguration<Appointment>
{
    public override void Configure(EntityTypeBuilder<Appointment> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Appointments");
        builder.HasOne(o => o.Doctor).WithMany().HasForeignKey(o => o.IdDoctor).IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(o => o.Patient).WithMany().HasForeignKey(o => o.IdPatient).IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(o => o.AppointmentCode).WithOne()
            .HasForeignKey<AppointmentCode>(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(o => o.Start).IsRequired();
        builder.Property(o => o.End).IsRequired();
        builder.Property(o => o.Status).IsRequired();
    }
}