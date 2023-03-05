using OfficeRetro.Application.Inquiry.Commands.InquiryFile;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands;

public record CreateInquiryAnswer(
    Guid InquiryKey,
    string Content,
    IEnumerable<CreateInquiryFile> Files) : ICommand;
