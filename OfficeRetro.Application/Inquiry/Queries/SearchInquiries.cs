using OfficeRetro.Application.Inquiry.DTO;
using OfficeRetro.Domain.Inquiry.ValueObjects;
using OfficeRetro.Shared.Transactions.Queries.Interfaces;

namespace OfficeRetro.Application.Inquiry.Queries;

public record SearchInquiries(
    InquiryWriter? Writer,
    InquiryTitle? Title,
    DateTime? StartAt,
    DateTime? EndAt) : IQuery<IEnumerable<InquiryDto>>;
