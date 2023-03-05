using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryTitleNullException : InquiryNullException
{
    public InquiryTitleNullException()
        : base(InquiryExceptionMessages.EMPTY_TITLE) { }
}
