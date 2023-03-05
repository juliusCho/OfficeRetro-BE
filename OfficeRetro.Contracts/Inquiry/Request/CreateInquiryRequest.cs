using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

namespace OfficeRetro.Contracts.Inquiry.Request;

public record CreateInquiryRequest(
    string Writer,
    string Title,
    string Content,
    string Password,
    IEnumerable<CreateInquiryFileRequest> Files);
