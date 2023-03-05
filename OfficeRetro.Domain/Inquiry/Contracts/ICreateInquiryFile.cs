namespace OfficeRetro.Domain.Inquiry.Contracts;

public interface ICreateInquiryFile
{
    public string Url { get; set; }
    public string MimeType { get; set; }
}
