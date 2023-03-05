using OfficeRetro.Contracts.Inquiry.InquiryAnswer.Response;
using OfficeRetro.Contracts.Inquiry.InquiryFile.Response;

namespace OfficeRetro.Contracts.Inquiry.Response;

public record InquiryResponse(
    Guid Key,
    string Writer,
    string Title,
    string Content,
    string Password,
    DateTime CreatedAt,
    DateTime ModifiedAt,
    IEnumerable<InquiryFileResponse> Files,
    InquiryAnswerResponse? Answer);
