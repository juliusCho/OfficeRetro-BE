using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryWriterNullException : InquiryNullException
{
    public InquiryWriterNullException()
        : base(InquiryExceptionMessages.EMPTY_WRITER) { }
}
