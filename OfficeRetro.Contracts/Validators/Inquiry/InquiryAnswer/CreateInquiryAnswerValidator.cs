using FluentValidation;
using OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;
using OfficeRetro.Contracts.Validators.Inquiry.InquiryFile;

namespace OfficeRetro.Contracts.Validators.Inquiry.InquiryAnswer;

public class CreateInquiryAnswerValidator : AbstractValidator<CreateInquiryAnswerRequest>
{
    public CreateInquiryAnswerValidator()
    {
        RuleFor(a => a.InquiryKey).NotNull().NotEmpty();
        RuleFor(a => a.Content).NotNull().NotEmpty();
        RuleForEach(a => a.Files).SetValidator(new CreateInquiryFileValidator());
    }
}
