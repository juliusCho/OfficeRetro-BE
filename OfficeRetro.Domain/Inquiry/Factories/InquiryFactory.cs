using OfficeRetro.Domain.Inquiry.Contracts;
using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Domain.Inquiry.Factories.Interfaces;
using OfficeRetro.Domain.Inquiry.ValueObjects.InquiryFile;

namespace OfficeRetro.Domain.Inquiry.Factories;

public sealed class InquiryFactory : IInquiryFactory
{
    public Entities.Inquiry Create(
        Guid key,
        string writer,
        string title,
        string content,
        string password,
        IEnumerable<ICreateInquiryFile> files)
    {
        var inquiry = new Entities.Inquiry(
            key,
            writer,
            title,
            content,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);

        inquiry.AddFiles(CreateFileCollection(
            files.Select(f => (IUpdateInquiryFile)f)));

        return inquiry;
    }

    public IEnumerable<InquiryFile> CreateFileCollection(
        IEnumerable<IUpdateInquiryFile> files)
        => files.Select(f => new InquiryFile(
            f.Key ?? Guid.NewGuid(),
            new InquiryFileUrl(f.Url),
            new InquiryFileMimeType(f.MimeType),
            f.CreatedAt ?? DateTime.UtcNow));
}
