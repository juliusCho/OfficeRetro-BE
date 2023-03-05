using FluentValidation;
using OfficeRetro.Contracts.Inquiry.Request;

namespace OfficeRetro.Contracts.Validators.Inquiry;

public class GetInquiryValidator : AbstractValidator<GetInquiryRequest>
{
    public GetInquiryValidator()
    {
        RuleFor(i => i.Key).NotNull().NotEmpty();
        RuleFor(i => i.Password).NotNull().NotEmpty();
    }
}
