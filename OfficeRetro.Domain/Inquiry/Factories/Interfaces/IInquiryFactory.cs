using OfficeRetro.Domain.Inquiry.Contracts;
using OfficeRetro.Domain.Inquiry.Entities;

namespace OfficeRetro.Domain.Inquiry.Factories.Interfaces;

public interface IInquiryFactory
{
    Entities.Inquiry Create(
        Guid key,
        string writer,
        string title,
        string content,
        string password,
        IEnumerable<ICreateInquiryFile> inquiryFiles);

    IEnumerable<InquiryFile> CreateFileCollection(
        IEnumerable<IUpdateInquiryFile> files);
}
