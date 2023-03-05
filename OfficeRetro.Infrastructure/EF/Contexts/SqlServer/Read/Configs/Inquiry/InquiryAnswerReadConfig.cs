using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Inquiry;

internal sealed class InquiryAnswerReadConfig : IEntityTypeConfiguration<InquiryAnswerReadModel>
{
    public void Configure(EntityTypeBuilder<InquiryAnswerReadModel> builder)
    {
        builder.HasKey(irm => irm.Id);
        builder.Property(i => i.Key);
        builder.Property(i => i.Content);
        builder.Property(i => i.CreatedAt);
        builder.Property(i => i.ModifiedAt);
        builder
            .HasMany(irm => irm.Files)
            .WithOne(ifm => ifm.Answer);
        builder.HasOne(irm => irm.Inquiry);
        builder.HasOne(irm => irm.User);

        builder.ToTable("InquiryAnswers");
    }
}
