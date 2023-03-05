namespace OfficeRetro.Application.Inquiry.DTO;

public class InquiryAnswerDto
{
    public Guid Key { get; init; }
    public string Writer { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime ModifiedAt { get; init; }
    public IEnumerable<InquiryFileDto> Files { get; init; } =
        Enumerable.Empty<InquiryFileDto>();
}
