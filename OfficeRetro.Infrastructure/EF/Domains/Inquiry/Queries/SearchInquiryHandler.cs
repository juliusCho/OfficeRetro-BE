using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using OfficeRetro.Application.Inquiry.DTO;
using OfficeRetro.Application.Inquiry.Queries;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;
using OfficeRetro.Shared.Transactions.Queries.Interfaces;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Queries;

internal sealed class SearchInquiryHandler : IQueryHandler<SearchInquiries, IEnumerable<InquiryDto>>
{
    private readonly DbSet<InquiryReadModel> _inquiries;
    private readonly IMapper _mapper;

    public SearchInquiryHandler(ReadDbContext context, IMapper mapper)
    {
        _inquiries = context.Inquiries;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InquiryDto>> HandleAsync(SearchInquiries query)
    {
        var inquiries = await _inquiries
            .Include(i => i.Answer)
#nullable disable
            .Where(i => string.IsNullOrWhiteSpace(query.Writer) ||
                i.Writer.ToLower().Contains(query.Writer.ToLower()))
            .Where(i => string.IsNullOrWhiteSpace(query.Title) ||
                i.Title.ToLower().Contains(query.Title.ToLower()))
#nullable restore
            .Where(i => query.StartAt == null || 
                DateTime.Compare(i.ModifiedAt, query.StartAt ?? i.ModifiedAt) <= 0)
            .Where(i => query.EndAt == null ||
                DateTime.Compare(i.ModifiedAt, query.EndAt ?? i.ModifiedAt) >= 0)
            .AsNoTracking()
            .ToListAsync();

        return inquiries.Select(_mapper.Map<InquiryDto>);
    }
}
