using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands;

public record RemoveInquiryAnswer(Guid InquiryKey, Guid Key) : ICommand;
