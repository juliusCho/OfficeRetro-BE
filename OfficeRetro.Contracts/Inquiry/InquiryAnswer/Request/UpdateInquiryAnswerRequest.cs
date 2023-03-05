using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

namespace OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;

public record UpdateInquiryAnswerRequest(
    Guid Key,
    Guid InquiryKey,
    string Content,
    DateTime CreatedAt,
    IEnumerable<UpdateInquiryFileRequest> Files);
