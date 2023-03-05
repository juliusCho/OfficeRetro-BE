using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Application.Inquiry.Exceptions;

public class InquiryNotExistsException : InquiryNotFoundException
{
    public InquiryNotExistsException(Guid key)
        : base($"{InquiryExceptionMessages.NOT_FOUND} [{key}]") { }
}
