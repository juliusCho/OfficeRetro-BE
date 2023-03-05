using OfficeRetro.Domain.Inquiry.Exceptions;

namespace OfficeRetro.Domain.Inquiry.ValueObjects;

public record InquiryTitle
{
    public string Value { get; }

    private const ushort _maxLength = 200;

    public InquiryTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InquiryTitleNullException();
        }

        if (value.Length > _maxLength)
        {
            throw new InquiryTitleMaxException(_maxLength);
        }

        Value = value;
    }

    public string ToLower() => Value.ToLower();

    public static implicit operator string(InquiryTitle inquiryTitle)
        => inquiryTitle.Value;

    public static explicit operator InquiryTitle(string value)
        => new(value);
}
