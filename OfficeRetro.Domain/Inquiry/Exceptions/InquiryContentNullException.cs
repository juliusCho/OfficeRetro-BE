using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryContentNullException : AuthNullException
{
    public InquiryContentNullException()
        : base(InquiryExceptionMessages.EMPTY_CONTENT) { }
}
