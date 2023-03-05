using OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

internal class InquiryAnswerReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public string Content { get; }
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; }
    public IEnumerable<InquiryAnswerFileReadModel> Files { get; } =
        Enumerable.Empty<InquiryAnswerFileReadModel>();
    public InquiryReadModel Inquiry { get; }
    public UserReadModel User { get; }
}
