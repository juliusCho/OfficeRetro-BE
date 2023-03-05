using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Exceptions;

internal class InquiryPasswordIncorrect : InquiryException
{
    public InquiryPasswordIncorrect() 
        : base(
            InquiryExceptionMessages.PASSWORD_INCORRECT, 
            System.Net.HttpStatusCode.BadRequest) { }
}
