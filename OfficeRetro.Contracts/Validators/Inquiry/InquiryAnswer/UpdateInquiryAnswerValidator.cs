using FluentValidation;
using OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;
using OfficeRetro.Contracts.Validators.Inquiry.InquiryFile;

namespace OfficeRetro.Contracts.Validators.Inquiry.InquiryAnswer;

public class UpdateInquiryAnswerValidator : AbstractValidator<UpdateInquiryAnswerRequest>
{
    public UpdateInquiryAnswerValidator()
    {
        RuleFor(a => a.Key).NotNull().NotEmpty();
        RuleFor(a => a.InquiryKey).NotNull().NotEmpty();
        RuleFor(a => a.Content).NotNull().NotEmpty();
        RuleFor(a => a.CreatedAt).NotNull().NotEmpty();
        RuleForEach(a => a.Files).SetValidator(new UpdateInquiryFileValidator());
    }
}
