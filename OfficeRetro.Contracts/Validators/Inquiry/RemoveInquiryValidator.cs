using FluentValidation;
using OfficeRetro.Contracts.Inquiry.Request;

namespace OfficeRetro.Contracts.Validators.Inquiry;

public class RemoveInquiryValidator : AbstractValidator<RemoveInquiryRequest>
{
    public RemoveInquiryValidator()
    {
        RuleFor(i => i.Key).NotNull().NotEmpty();
        RuleFor(i => i.Password).NotNull().NotEmpty();
    }
}
