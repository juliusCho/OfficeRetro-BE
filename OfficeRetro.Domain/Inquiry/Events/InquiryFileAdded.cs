using OfficeRetro.Domain.Inquiry.Entities;
using OfficeRetro.Shared.Domain;

namespace OfficeRetro.Domain.Inquiry.Events;

/**TODO: Not sure what this record object has got anything to do with events*/
internal record InquiryFileAdded(
    Entities.Inquiry Inquiry,
    InquiryFile InquiryFile) : IDomainEvent;
