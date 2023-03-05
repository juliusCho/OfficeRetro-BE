using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions;

internal class InquiryPasswordWeakException : InquiryException
{
    public InquiryPasswordWeakException()
        : base(
            InquiryExceptionMessages.PASSWORD_WEAK,
            System.Net.HttpStatusCode.BadRequest) { }
}
