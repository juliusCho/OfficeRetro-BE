using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Exceptions;

internal class InquiryNotFound : InquiryNotFoundException
{
    public InquiryNotFound() : base(InquiryExceptionMessages.NOT_FOUND) { }
}
