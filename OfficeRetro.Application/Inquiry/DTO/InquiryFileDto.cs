namespace OfficeRetro.Application.Inquiry.DTO;

public class InquiryFileDto
{
    public Guid Key { get; init; }
    public string Url { get; init; } = string.Empty;
    public string MimeType { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}
