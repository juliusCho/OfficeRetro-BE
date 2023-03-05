using OfficeRetro.Application.Inquiry.Commands.InquiryFile;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands;

public record UpdateInquiry(
    Guid Key,
    string Writer,
    string Title,
    string Content,
    string Password,
    DateTime CreatedAt,
    IEnumerable<UpdateInquiryFile> Files) : ICommand;