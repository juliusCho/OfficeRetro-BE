using OfficeRetro.Domain.Auth.Entities;
using OfficeRetro.Domain.Inquiry.Exceptions.InquiryAnswer;
using OfficeRetro.Shared.Enums.Auth;

namespace OfficeRetro.Domain.Inquiry.ValueObjects;

public record InquiryAnswerWriterId
{
    public long Value { get; }

    public InquiryAnswerWriterId(User value)
    {
        if (value.Id == 0 || !Enum.IsDefined(value.Role))
        {
            throw new InquiryAnswerWriterInfoException();
        }

        if (value.Role is not UserRole.Admin)
        {
            throw new InquiryAnswerWriterPermissionException();
        }

        Value = value.Id;
    }

    public static implicit operator long(InquiryAnswerWriterId inquiryAnswerWriterId)
        => inquiryAnswerWriterId.Value;

    public static explicit operator InquiryAnswerWriterId(User value)
        => new(value);
}
