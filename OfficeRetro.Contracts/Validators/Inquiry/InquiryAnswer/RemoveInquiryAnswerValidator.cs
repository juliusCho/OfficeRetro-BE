using FluentValidation;
using OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;

namespace OfficeRetro.Contracts.Validators.Inquiry.InquiryAnswer;

public class RemoveInquiryAnswerValidator : AbstractValidator<RemoveInquiryAnswerRequest>
{
    public RemoveInquiryAnswerValidator()
    {
        RuleFor(a => a.Key).NotNull().NotEmpty();
        RuleFor(a => a.InquiryKey).NotNull().NotEmpty();
    }
}
