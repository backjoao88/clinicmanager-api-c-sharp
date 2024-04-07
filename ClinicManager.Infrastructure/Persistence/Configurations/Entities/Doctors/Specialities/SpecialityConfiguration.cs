using ClinicManager.Domain.Core.Doctors.Specialities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Doctors.Specialities;

public class SpecialityConfiguration : BaseConfiguration<Speciality>
{
    public override void Configure(EntityTypeBuilder<Speciality> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Specialities");
        builder.Property(o => o.SpecialityArea).IsRequired();
        builder.HasData(SpecialityTypes.DefaultSpecialities);
    } 
}