namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

internal class InquiryReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public string Writer { get; } = string.Empty;
    public string Title { get; } = string.Empty;
    public string Content { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; }
    public IEnumerable<InquiryFileReadModel> Files { get; } =
        Enumerable.Empty<InquiryFileReadModel>();
    public InquiryAnswerReadModel? Answer { get; }
}
