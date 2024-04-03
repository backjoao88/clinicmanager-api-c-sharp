using ClinicManager.Domain.Core.Integration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Entities.Integration;

/// <inheritdoc />
public class CredentialConfiguration : BaseConfiguration<Credential>
{
    public override void Configure(EntityTypeBuilder<Credential> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Credentials");
        builder.Property(o => o.Issuer).IsRequired();
        builder.Property(o => o.AccessToken).IsRequired();
        builder.Property(o => o.RefreshToken).IsRequired();
        builder.Property(o => o.ExpiresIn).IsRequired();
    }
}