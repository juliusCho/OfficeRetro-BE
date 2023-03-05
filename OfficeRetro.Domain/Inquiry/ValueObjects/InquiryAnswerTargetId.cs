using OfficeRetro.Domain.Inquiry.Exceptions.InquiryAnswer;

namespace OfficeRetro.Domain.Inquiry.ValueObjects;

public record InquiryAnswerTargetId
{
    public long Value { get; }

    public InquiryAnswerTargetId(long value)
    {
        if (value == 0)
        {
            throw new InquiryAnswerTargetEmptyException();
        }

        Value = value;
    }

    public static implicit operator long(InquiryAnswerTargetId inquiryAnswerTargetId)
        => inquiryAnswerTargetId.Value;

    public static explicit operator InquiryAnswerTargetId(long value)
        => new(value);
}
