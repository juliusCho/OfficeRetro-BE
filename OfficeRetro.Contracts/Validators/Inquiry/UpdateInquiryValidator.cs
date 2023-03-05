using FluentValidation;
using OfficeRetro.Contracts.Inquiry.Request;
using OfficeRetro.Contracts.Validators.Inquiry.InquiryFile;

namespace OfficeRetro.Contracts.Validators.Inquiry;

public class UpdateInquiryValidator : AbstractValidator<UpdateInquiryRequest>
{
    public UpdateInquiryValidator()
    {
        RuleFor(i => i.Key).NotNull().NotEmpty();
        RuleFor(i => i.Writer).NotNull().NotEmpty();
        RuleFor(i => i.Title).NotNull().NotEmpty();
        RuleFor(i => i.Content).NotNull().NotEmpty();
        RuleFor(i => i.Password).NotNull().NotEmpty();
        RuleFor(i => i.CreatedAt).NotNull().NotEmpty();
        RuleForEach(i => i.Files).SetValidator(new UpdateInquiryFileValidator());
    }
}
