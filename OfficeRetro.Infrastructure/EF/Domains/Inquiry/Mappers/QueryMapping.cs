using Mapster;
using OfficeRetro.Application.Inquiry.DTO;
using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

namespace OfficeRetro.Infrastructure.EF.Domains.Inquiry.Mappers;

public class QueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InquiryReadModel, InquiryDto>();
        config.NewConfig<InquiryFileReadModel, InquiryFileDto>();
        config.NewConfig<InquiryAnswerReadModel, InquiryAnswerDto>()
            .Map(dest => dest.Writer, src => src.User.FirstName);
        config.NewConfig<InquiryAnswerFileReadModel, InquiryFileDto>();
    }
}
