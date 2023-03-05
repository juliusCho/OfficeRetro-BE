namespace OfficeRetro.Contracts.Inquiry.InquiryFile.Response;

public class InquiryFileResponse
{
    public Guid Key { get; set; }
    public string Url { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
