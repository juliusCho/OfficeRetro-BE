using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Auth;

internal sealed class UserPasswordResetReadConfig
    : IEntityTypeConfiguration<UserPasswordResetReadModel>
{
    public void Configure(EntityTypeBuilder<UserPasswordResetReadModel> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Key);
        builder.Property(p => p.ResetConfirmCode);
        builder.Property(p => p.ExpiryTime);
        builder.Property(p => p.CreatedAt);
        builder.HasOne(p => p.User);

        builder.ToTable("UserPasswordResets");
    }
}
