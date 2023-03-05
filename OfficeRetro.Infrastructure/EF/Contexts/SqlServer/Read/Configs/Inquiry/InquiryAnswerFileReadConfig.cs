using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read.Configs.Inquiry;

internal sealed class InquiryAnswerFileReadConfig : IEntityTypeConfiguration<InquiryAnswerFileReadModel>
{
    public void Configure(EntityTypeBuilder<InquiryAnswerFileReadModel> builder)
    {
        builder.HasKey(irm => irm.Id);
        builder.Property(i => i.Key);
        builder.Property(i => i.Url);
        builder.Property(i => i.MimeType);
        builder.Property(i => i.CreatedAt);
        builder.HasOne(irm => irm.Answer);
        builder.ToTable("InquiryAnswerFiles");
    }
}
