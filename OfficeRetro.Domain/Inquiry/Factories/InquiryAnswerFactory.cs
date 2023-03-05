using OfficeRetro.Domain.Auth.Entities;
using OfficeRetro.Domain.Inquiry.Contracts;
using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Domain.Inquiry.Factories.Interfaces;
using OfficeRetro.Domain.Inquiry.ValueObjects.InquiryFile;

namespace OfficeRetro.Domain.Inquiry.Factories;

public sealed class InquiryAnswerFactory : IInquiryAnswerFactory
{
    public InquiryAnswer Create(
        Guid key,
        User user,
        Entities.Inquiry inquiry,
        string content,
        IEnumerable<ICreateInquiryFile> files)
    {
        var inquiryAnswer = new InquiryAnswer(
            key,
            user,
            inquiry.Id,
            content,
            DateTime.UtcNow,
            DateTime.UtcNow);

        inquiryAnswer.AddFiles(CreateFileCollection(
            files.Select(f => (IUpdateInquiryFile)f)));

        return inquiryAnswer;
    }

    public IEnumerable<InquiryAnswerFile> CreateFileCollection(
        IEnumerable<IUpdateInquiryFile> files)
        => files.Select(f => new InquiryAnswerFile(
            f.Key ?? Guid.NewGuid(),
            new InquiryFileUrl(f.Url),
            new InquiryFileMimeType(f.MimeType),
            f.CreatedAt ?? DateTime.UtcNow));
}
