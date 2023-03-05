using OfficeRetro.Application.Inquiry.Commands.InquiryFile;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands;

public class CreateInquiry : ICommand
{
    public Guid Key { get; } = Guid.NewGuid();
    public string Writer { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string Password { get; init; }
    public IEnumerable<CreateInquiryFile> Files { get; init; }
}
