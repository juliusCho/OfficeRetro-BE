using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Application.Inquiry.Exceptions;

public class InquiryExistsException : InquiryException
{
    public InquiryExistsException(Guid key)
        : base(
            $"{InquiryExceptionMessages.ALREADY_EXISTS} [{key}]", 
            System.Net.HttpStatusCode.Conflict) { }
}
