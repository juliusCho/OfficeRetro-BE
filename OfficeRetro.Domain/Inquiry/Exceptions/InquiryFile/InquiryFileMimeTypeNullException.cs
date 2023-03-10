using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

internal class InquiryFileMimeTypeNullException : InquiryNullException
{
    public InquiryFileMimeTypeNullException()
        : base(InquiryExceptionMessages.File.EMPTY_MIME_TYPE) { }
}
