using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Inquiry;

internal sealed class InquiryReadConfig : IEntityTypeConfiguration<InquiryReadModel>
{
    public void Configure(EntityTypeBuilder<InquiryReadModel> builder)
    {
        builder.HasKey(irm => irm.Id);
        builder.Property(i => i.Key);
        builder.Property(i => i.Writer);
        builder.Property(i => i.Title);
        builder.Property(i => i.Content);
        builder.Property(i => i.Password);
        builder.Property(i => i.CreatedAt);
        builder.Property(i => i.ModifiedAt);
        builder
            .HasMany(irm => irm.Files)
            .WithOne(ifm => ifm.Inquiry);
        builder.HasOne(i => i.Answer);

        builder.ToTable("Inquiries");
    }
}
