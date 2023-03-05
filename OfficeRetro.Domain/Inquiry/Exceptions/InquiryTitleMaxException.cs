using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryTitleMaxException : AuthMaxException
{
    public InquiryTitleMaxException(ushort length)
        : base(InquiryExceptionMessages.TITLE_MAX, length) { }
}
