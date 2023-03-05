using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

internal class InquiryFileUrlMaxException : InquiryMaxException
{
    public InquiryFileUrlMaxException(ushort length)
        : base(InquiryExceptionMessages.File.URL_MAX, length) { }
}
