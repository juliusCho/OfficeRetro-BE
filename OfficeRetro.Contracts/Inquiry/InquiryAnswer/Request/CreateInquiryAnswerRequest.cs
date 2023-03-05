using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;
using OfficeRetro.Shared.Enums.Auth;

namespace OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;

public record CreateInquiryAnswerRequest(
    Guid UserKey,
    UserRole UserRole,
    string Content,
    IEnumerable<CreateInquiryFileRequest> Files);
