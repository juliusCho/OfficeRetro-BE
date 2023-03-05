using OfficeRetro.Contracts.Inquiry.InquiryFile.Response;

namespace OfficeRetro.Contracts.Inquiry.Response;

public record SearchInquiriesResponse(
    Guid Key,
    string Writer,
    string Title,
    string Content,
    string Password,
    DateTime CreatedAt,
    DateTime ModifiedAt,
    IEnumerable<InquiryFileResponse> Files,
    bool IsAnswered);
