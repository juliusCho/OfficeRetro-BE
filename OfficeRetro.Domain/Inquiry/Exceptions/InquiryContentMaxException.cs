using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryContentMaxException : InquiryMaxException
{
    public InquiryContentMaxException(ushort length)
        : base(InquiryExceptionMessages.CONTENT_MAX, length) { }
}
