using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Auth;

internal sealed class UserActivationReadConfig
    : IEntityTypeConfiguration<UserActivationReadModel>
{
    public void Configure(EntityTypeBuilder<UserActivationReadModel> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Key);
        builder.Property(t => t.ActivatedCode);
        builder.Property(t => t.ExpiryTime);
        builder.Property(t => t.CreatedAt);
        builder.HasOne(t => t.User);

        builder.ToTable("UserActivations");
    }
}
