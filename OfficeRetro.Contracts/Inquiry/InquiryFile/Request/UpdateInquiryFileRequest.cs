namespace OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

public record UpdateInquiryFileRequest(
    Guid? Key,
    string Url,
    string MimeType,
    DateTime? CreatedAt);
