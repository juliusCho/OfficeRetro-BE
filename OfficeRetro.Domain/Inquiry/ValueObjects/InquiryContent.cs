using OfficeRetro.Domain.Inquiry.Exceptions;

namespace OfficeRetro.Domain.Inquiry.ValueObjects;

public record InquiryContent
{
    public string Value { get; }

    private const ushort _maxLength = 10000;

    public InquiryContent(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InquiryContentNullException();
        }

        if (value.Length > _maxLength) 
        {
            throw new InquiryContentMaxException(_maxLength);
        }

        Value = value;
    }

    public static implicit operator string(InquiryContent inquiryContent)
        => inquiryContent.Value;

    public static explicit operator InquiryContent(string value)
        => new(value);
}
