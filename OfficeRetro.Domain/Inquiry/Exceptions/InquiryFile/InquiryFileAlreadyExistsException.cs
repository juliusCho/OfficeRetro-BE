using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

internal class InquiryFileAlreadyExistsException : InquiryException
{
    public InquiryFileAlreadyExistsException()
        : base(
            InquiryExceptionMessages.File.ALREADY_EXISTS,
            System.Net.HttpStatusCode.Conflict) { }
}
