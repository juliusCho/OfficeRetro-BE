using Microsoft.EntityFrameworkCore;
using OfficeRetro.Domain.Inquiry.Repositories;
using OfficeRetro.Infrastructure.EF.Contexts.SqlServer.Write;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Repositories;

internal sealed class InquiryRepository : IInquiryRepository
{
    private readonly WriteDbContext _context;
    private readonly DbSet<Domain.Inquiry.Entities.Inquiry> _inquiries;

    public InquiryRepository(WriteDbContext context)
    {
        _context = context;
        _inquiries = context.Inquiries;
    }

    public async Task CreateAsync(Domain.Inquiry.Entities.Inquiry inquiry)
    {
        await _inquiries.AddAsync(inquiry);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.Inquiry.Entities.Inquiry inquiry)
    {
        _inquiries.Remove(inquiry);
        await _context.SaveChangesAsync();
    }

    public Task<Domain.Inquiry.Entities.Inquiry?> GetAsync(Guid key)
    {
        return _inquiries
            .Include("_files")
            .SingleOrDefaultAsync(i => i.Key.Equals(key));
    }

    public async Task UpdateAsync(Domain.Inquiry.Entities.Inquiry inquiry)
    {
        _inquiries.Update(inquiry);
        await _context.SaveChangesAsync();
    }
}
