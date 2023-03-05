using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryWriterMaxException : InquiryMaxException
{
    public InquiryWriterMaxException(ushort length)
        : base(InquiryExceptionMessages.WRITER_MAX, length) { }
}
