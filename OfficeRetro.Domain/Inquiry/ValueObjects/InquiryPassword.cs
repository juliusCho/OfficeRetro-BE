using OfficeRetro.Domain.Helpers.Validators;
using OfficeRetro.Domain.Inquiry.Exceptions;

namespace OfficeRetro.Domain.Inquiry.ValueObjects;

public record InquiryPassword
{
    public string Value { get; }

    public InquiryPassword(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InquiryPasswordNullException();
        }

        if (!PasswordValidator.IsStrong(value))
        {
            throw new InquiryPasswordWeakException();
        }

        Value = value;
    }

    public static implicit operator string(InquiryPassword inquiryPassword)
        => inquiryPassword.Value;

    public static explicit operator InquiryPassword(string value)
        => new(value);
}
