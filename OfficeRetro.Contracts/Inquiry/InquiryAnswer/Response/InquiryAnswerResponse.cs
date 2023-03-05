using OfficeRetro.Contracts.Inquiry.InquiryFile.Response;

namespace OfficeRetro.Contracts.Inquiry.InquiryAnswer.Response;

public record InquiryAnswerResponse(
    Guid Key,
    string Writer,
    string Content,
    DateTime CreatedAt,
    DateTime ModifiedAt,
    IEnumerable<InquiryFileResponse> Files);
