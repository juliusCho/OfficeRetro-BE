using OfficeRetro.Domain.Inquiry.Contracts;

namespace OfficeRetro.Application.Inquiry.Commands.InquiryFile;

public class CreateInquiryFile : ICreateInquiryFile
{
    public string Url { get; set; }
    public string MimeType { get; set; }
}
