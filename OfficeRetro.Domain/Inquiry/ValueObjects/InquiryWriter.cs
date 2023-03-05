using OfficeRetro.Domain.Inquiry.Exceptions;

namespace OfficeRetro.Domain.Inquiry.ValueObjects;

public record InquiryWriter
{
    public string Value { get; }

    private const ushort _maxLength = 100;

    public InquiryWriter(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InquiryWriterNullException();
        }

        if (value.Length > _maxLength)
        {
            throw new InquiryWriterMaxException(_maxLength);
        }

        Value = value;
    }

    public string ToLower() => Value.ToLower();

    public static implicit operator string(InquiryWriter inquiryWriter)
        => inquiryWriter.Value;

    public static explicit operator InquiryWriter(string value)
        => new(value);
}
