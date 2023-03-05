using OfficeRetro.Application.Inquiry.Commands.InquiryFile;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands;

public record UpdateInquiryAnswer(
    Guid Key,
    Guid InquiryKey,
    string Content,
    DateTime CreatedAt,
    IEnumerable<UpdateInquiryFile> Files) : ICommand;
