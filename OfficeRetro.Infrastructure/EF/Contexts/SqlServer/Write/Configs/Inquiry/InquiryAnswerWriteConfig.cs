using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Domain.Inquiry.ValueObjects;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write.Configs.Inquiry;

internal sealed class InquiryAnswerWriteConfig : IEntityTypeConfiguration<InquiryAnswer>
{
    public void Configure(EntityTypeBuilder<InquiryAnswer> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Key);

        var writerConverter = new ValueConverter<InquiryWriter, string>(
            iw => iw.Value,
            w => new InquiryWriter(w));
        var contentConverter = new ValueConverter<InquiryContent, string>(
            ic => ic.Value,
            c => new InquiryContent(c));

        builder
            .Property(typeof(InquiryWriter), "_writer")
            .HasConversion(writerConverter)
            .HasColumnName("Writer");
        builder
            .Property(typeof(InquiryContent), "_content")
            .HasConversion(contentConverter)
            .HasColumnName("Content");
        builder
            .Property("_createdAt")
            .HasColumnName("CreatedAt");
        builder
            .Property("_modifiedAt")
            .HasColumnName("ModifiedAt");

        builder.HasMany(typeof(InquiryAnswerFile), "_files");

        builder.ToTable("InquiryAnswers");
    }
}
