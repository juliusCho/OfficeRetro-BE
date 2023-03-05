using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Auth;

internal sealed class UserReadConfig : IEntityTypeConfiguration<UserReadModel>
{
    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Key);
        builder.Property(u => u.Email);
        builder.Property(u => u.Password);
        builder.Property(u => u.FirstName);
        builder.Property(u => u.LastName);
        builder.Property(u => u.Role);
        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.ModifiedAt);
        builder.HasOne(u => u.RefreshToken);
        builder.HasOne(u => u.Activation);
        builder.HasOne(u => u.PasswordReset);
        builder
            .HasMany(u => u.InquiryAnswers)
            .WithOne(a => a.User);

        builder.ToTable("Users");
    }
}
