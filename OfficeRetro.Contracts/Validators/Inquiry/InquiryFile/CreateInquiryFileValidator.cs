using FluentValidation;
using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

namespace OfficeRetro.Contracts.Validators.Inquiry.InquiryFile;

public class CreateInquiryFileValidator : AbstractValidator<CreateInquiryFileRequest>
{
    public CreateInquiryFileValidator()
    {
        RuleFor(f => f.Url).NotNull().NotEmpty();
        RuleFor(f => f.MimeType).NotNull().NotEmpty();
    }
}
