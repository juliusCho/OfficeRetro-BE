using OfficeRetro.Domain.Inquiry.ValueObjects.InquiryFile;

namespace OfficeRetro.Domain.Inquiry.Entities;

public record InquiryAnswerFile
{
    public long Id { get; }
    public Guid Key { get; }
    public InquiryFileUrl Url { get; }
    public InquiryFileMimeType MimeType { get; }
    public DateTime CreatedAt { get; }

    public InquiryAnswerFile(
        Guid key,
        InquiryFileUrl url,
        InquiryFileMimeType mimeType,
        DateTime createdAt)
    {
        Key = key;
        Url = url;
        MimeType = mimeType;
        CreatedAt = createdAt;
    }
}
