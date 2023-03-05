using OfficeRetro.Domain.Helpers.Validators;
using OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

namespace OfficeRetro.Domain.Inquiry.ValueObjects.InquiryFile;

public record InquiryFileUrl
{
    public string Value { get; }

    private const ushort _maxLength = 200;

    public InquiryFileUrl(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InquiryFileUrlNullException();
        }

        if (!UrlValidator.IsValid(value))
        {
            throw new InquiryFileUrlInvalidException();
        }
        
        if (value.Length > _maxLength)
        {
            throw new InquiryFileUrlMaxException(_maxLength);
        }

        Value = value;
    }

    public static implicit operator string(InquiryFileUrl inquiryFileUrl)
        => inquiryFileUrl.Value;

    public static explicit operator InquiryFileUrl(string value)
        => new(value);
}
