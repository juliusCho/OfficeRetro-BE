using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

internal class InquiryFileUrlInvalidException : InquiryException
{
    public InquiryFileUrlInvalidException()
        : base(
            InquiryExceptionMessages.File.URL_INVALID,
            System.Net.HttpStatusCode.BadRequest) { }
}
