using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryPasswordNullException : InquiryNullException
{
    public InquiryPasswordNullException()
        : base(InquiryExceptionMessages.EMPTY_PASSWORD) { }
}
