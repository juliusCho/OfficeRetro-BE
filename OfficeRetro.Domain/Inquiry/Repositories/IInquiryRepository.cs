namespace OfficeRetro.Domain.Inquiry.Repositories;

public interface IInquiryRepository
{
    Task<Entities.Inquiry?> GetAsync(Guid key);
    Task CreateAsync(Entities.Inquiry inquiry);
    Task UpdateAsync(Entities.Inquiry inquiry);
    Task DeleteAsync(Entities.Inquiry inquiry);
}
