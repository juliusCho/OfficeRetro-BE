using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryAnswer;

internal class InquiryAnswerWriterInfoException : InquiryException
{
    public InquiryAnswerWriterInfoException() 
        : base(InquiryExceptionMessages.Answer.INVALID_USER) { }
}
