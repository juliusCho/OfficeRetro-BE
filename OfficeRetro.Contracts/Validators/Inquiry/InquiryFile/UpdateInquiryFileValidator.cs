using FluentValidation;
using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;

namespace OfficeRetro.Contracts.Validators.Inquiry.InquiryFile;

public class UpdateInquiryFileValidator : AbstractValidator<UpdateInquiryFileRequest>
{
    public UpdateInquiryFileValidator()
    {
        RuleFor(f => f.Url).NotNull().NotEmpty();
        RuleFor(f => f.MimeType).NotNull().NotEmpty();
    }
}
