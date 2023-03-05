using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryAnswer;

internal class InquiryAnswerTargetEmptyException : InquiryNullException
{
    public InquiryAnswerTargetEmptyException() 
        : base(InquiryExceptionMessages.Answer.EMPTY_TARGET) { }
}
