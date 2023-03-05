using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Domain.Inquiry.ValueObjects.InquiryFile;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write.Configs.Inquiry;

internal sealed class InquiryFileWriteConfig : IEntityTypeConfiguration<InquiryFile>
{
    public void Configure(EntityTypeBuilder<InquiryFile> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Key);
        builder
            .Property(f => f.Url)
            .HasConversion(ifu => ifu.Value, v => new InquiryFileUrl(v));
        builder
            .Property(f => f.MimeType)
            .HasConversion(ifmt => ifmt.Value, v => new InquiryFileMimeType(v));
        builder.Property(f => f.CreatedAt);

        builder.ToTable("InquiryFiles");
    }
}
