using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryPasswordNullException : AuthNullException
{
    public InquiryPasswordNullException()
        : base(InquiryExceptionMessages.EMPTY_PASSWORD) { }
}
