using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using OfficeRetro.Application.Inquiry.DTO;
using OfficeRetro.Application.Inquiry.Queries;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Read;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Exceptions;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;
using OfficeRetro.Shared.Transactions.Queries.Interfaces;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Queries;

internal sealed class GetInquiryHandler : IQueryHandler<GetInquiry, InquiryDto>
{
    private readonly DbSet<InquiryReadModel> _inquiries;
    private readonly IMapper _mapper;

    public GetInquiryHandler(ReadDbContext context, IMapper mapper)
    {
        _inquiries = context.Inquiries;
        _mapper = mapper;
    }

    public async Task<InquiryDto> HandleAsync(GetInquiry query)
    {
        var inquiry = await _inquiries
            .Include(i => i.Files)
#nullable disable
            .Include(i => i.Answer)
                .ThenInclude(a => a.Files)
            .Include(i => i.Answer)
                .ThenInclude(a => a.User)
#nullable restore
            .Where(i => query.Key.Equals(i.Key))
            .AsNoTracking()
            .SingleOrDefaultAsync();

        if (inquiry is null) throw new InquiryNotFound();

        if (!query.Password.Equals(inquiry.Password)) throw new InquiryPasswordIncorrect();

        return _mapper.Map<InquiryDto>(inquiry);
    }
}
