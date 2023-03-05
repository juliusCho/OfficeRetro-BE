using OfficeRetro.Domain.Inquiry.Entities;

namespace OfficeRetro.Domain.Inquiry.Repositories;

public interface IInquiryAnswerRepository
{
    Task<InquiryAnswer?> GetAsync(Guid key);
    Task CreateAsync(InquiryAnswer inquiryAnswer);
    Task UpdateAsync(InquiryAnswer inquiryAnswer);
    Task DeleteAsync(InquiryAnswer inquiryAnswer);
}
