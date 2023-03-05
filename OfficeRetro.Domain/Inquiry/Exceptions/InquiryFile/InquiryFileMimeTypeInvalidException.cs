using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

internal class InquiryFileMimeTypeInvalidException : InquiryException
{
    public InquiryFileMimeTypeInvalidException()
        : base(
            InquiryExceptionMessages.File.MIME_TYPE_INVALID,
            System.Net.HttpStatusCode.BadRequest) { }
}
