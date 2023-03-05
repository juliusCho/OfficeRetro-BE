namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

internal class InquiryFileReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public string Url { get; } = string.Empty;
    public string MimeType { get; } = string.Empty;
    public DateTime CreatedAt { get; }

    public InquiryReadModel Inquiry { get; }
}
