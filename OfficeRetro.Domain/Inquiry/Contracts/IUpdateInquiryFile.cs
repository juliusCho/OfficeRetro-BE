namespace OfficeRetro.Domain.Inquiry.Contracts;

public interface IUpdateInquiryFile : ICreateInquiryFile
{
    public Guid? Key { get; set; }
    public DateTime? CreatedAt { get; set; }
}
