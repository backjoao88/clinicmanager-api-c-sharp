using ClinicManager.Domain.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Users;

/// <inheritdoc />
public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Users");
        builder.Property(o => o.Email).IsRequired();
        builder.Property(o => o.Password).IsRequired();
        builder.Property(o => o.Role).IsRequired();
    }
}