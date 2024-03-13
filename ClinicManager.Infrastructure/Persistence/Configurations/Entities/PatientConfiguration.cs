using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities;

/// <inheritdoc />
public class PatientConfiguration : BaseConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Patients");
        builder.Property(o => o.FirstName).IsRequired();
        builder.Property(o => o.LastName).IsRequired();
    }
}