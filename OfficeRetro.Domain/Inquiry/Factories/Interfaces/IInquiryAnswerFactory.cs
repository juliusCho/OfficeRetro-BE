using OfficeRetro.Domain.Auth.Entities;
using OfficeRetro.Domain.Inquiry.Contracts;
using OfficeRetro.Domain.Inquiry.Entities;

namespace OfficeRetro.Domain.Inquiry.Factories.Interfaces;

public interface IInquiryAnswerFactory
{
    InquiryAnswer Create(
        Guid key,
        User user,
        Entities.Inquiry inquiry,
        string content,
        IEnumerable<ICreateInquiryFile> files);

    IEnumerable<InquiryAnswerFile> CreateFileCollection(
        IEnumerable<IUpdateInquiryFile> files);
}
