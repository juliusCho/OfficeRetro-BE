using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Application.Inquiry.Exceptions;

public class InquiryFileExistsException : InquiryException
{
    public InquiryFileExistsException(Guid key)
        : base(
            $"{InquiryExceptionMessages.File.ALREADY_EXISTS} with the key of [{key}]",
            System.Net.HttpStatusCode.Conflict) { }
}
