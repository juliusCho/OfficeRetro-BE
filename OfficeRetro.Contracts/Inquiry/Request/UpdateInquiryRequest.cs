using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

namespace OfficeRetro.Contracts.Inquiry.Request;

public record UpdateInquiryRequest(
    Guid Key,
    string Writer,
    string Title,
    string Content,
    string Password,
    DateTime CreatedAt,
    IEnumerable<UpdateInquiryFileRequest> Files);
