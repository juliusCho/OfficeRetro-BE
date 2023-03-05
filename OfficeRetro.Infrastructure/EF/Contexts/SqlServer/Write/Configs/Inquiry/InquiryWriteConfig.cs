using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Domain.Inquiry.ValueObjects;

namespace OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write.Configs.Inquiry;

internal sealed class InquiryWriteConfig : IEntityTypeConfiguration<Domain.Inquiry.Entities.Inquiry>
{
    public void Configure(EntityTypeBuilder<Domain.Inquiry.Entities.Inquiry> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Key);

        var writerConverter = new ValueConverter<InquiryWriter, string>(
            iw => iw.Value,
            w => new InquiryWriter(w));
        var titleConverter = new ValueConverter<InquiryTitle, string>(
            it => it.Value,
            t => new InquiryTitle(t));
        var contentConverter = new ValueConverter<InquiryContent, string>(
            ic => ic.Value,
            c => new InquiryContent(c));
        var passwordConverter = new ValueConverter<InquiryPassword, string>(
            ip => ip.Value,
            p => new InquiryPassword(p));

        builder
            .Property(typeof(InquiryWriter), "_writer")
            .HasConversion(writerConverter)
            .HasColumnName("Writer");
        builder
            .Property(typeof(InquiryTitle), "_title")
            .HasConversion(titleConverter)
            .HasColumnName("Title");
        builder
            .Property(typeof(InquiryContent), "_content")
            .HasConversion(contentConverter)
            .HasColumnName("Content");
        builder
            .Property(typeof(InquiryPassword), "_password")
            .HasConversion(passwordConverter)
            .HasColumnName("Password");
        builder
            .Property("_createdAt")
            .HasColumnName("CreatedAt");
        builder
            .Property("_modifiedAt")
            .HasColumnName("ModifiedAt");

        builder.HasMany(typeof(InquiryFile), "_files");

        builder.ToTable("Inquiries");
    }
}
