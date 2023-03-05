using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

namespace OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;

public record CreateInquiryAnswerRequest(
    Guid InquiryKey,
    string Content,
    IEnumerable<CreateInquiryFileRequest> Files);
