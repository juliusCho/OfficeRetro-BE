using OfficeRetro.Application.Inquiry.DTO;
using OfficeRetro.Domain.Inquiry.ValueObjects;
using OfficeRetro.Shared.Transactions.Queries.Interfaces;

namespace OfficeRetro.Application.Inquiry.Queries;

public record GetInquiry(
    Guid Key, 
    InquiryPassword Password) : IQuery<InquiryDto>;
