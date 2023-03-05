using OfficeRetro.Domain.Inquiry.Contracts;

namespace OfficeRetro.Application.Inquiry.Commands.InquiryFile;

public class UpdateInquiryFile : IUpdateInquiryFile
{
    public Guid? Key { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string Url { get; set; }
    public string MimeType { get; set; }
}
