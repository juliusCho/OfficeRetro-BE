using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryAnswer;

internal class InquiryAnswerWriterPermissionException : InquiryException
{
    public InquiryAnswerWriterPermissionException() 
        : base(InquiryExceptionMessages.Answer.USER_NO_PERMIT) { }
}
