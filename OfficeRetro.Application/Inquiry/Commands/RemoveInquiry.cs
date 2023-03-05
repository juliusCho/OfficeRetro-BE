using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands;

public record RemoveInquiry(Guid Key, string Password) : ICommand;
