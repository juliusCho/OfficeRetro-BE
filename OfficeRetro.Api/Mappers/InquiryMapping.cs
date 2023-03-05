using Mapster;
using OfficeRetro.Application.Inquiry.Commands;
using OfficeRetro.Application.Inquiry.Commands.InquiryFile;
using OfficeRetro.Application.Inquiry.DTO;
using OfficeRetro.Application.Inquiry.Queries;
using OfficeRetro.Contracts.Inquiry.InquiryAnswer.Request;
using OfficeRetro.Contracts.Inquiry.InquiryFile.Request;
using OfficeRetro.Contracts.Inquiry.InquiryFile.Response;
using OfficeRetro.Contracts.Inquiry.Request;
using OfficeRetro.Contracts.Inquiry.Response;

namespace OfficeRetro.Api.Mappers;

public class InquiryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        Request(config);
        Response(config);
    }

    private void Request(TypeAdapterConfig config)
    {
        config.NewConfig<GetInquiryRequest, GetInquiry>();
        config.NewConfig<SearchInquiriesRequest, SearchInquiries>();

        config.NewConfig<CreateInquiryRequest, CreateInquiry>();
        config.NewConfig<UpdateInquiryRequest, UpdateInquiry>();
        config.NewConfig<RemoveInquiryRequest, RemoveInquiry>();

        config.NewConfig<CreateInquiryFileRequest, CreateInquiryFile>();
        config.NewConfig<UpdateInquiryFileRequest, UpdateInquiryFile>();

        config.NewConfig<CreateInquiryAnswerRequest, CreateInquiryAnswer>();
        config.NewConfig<UpdateInquiryAnswerRequest, UpdateInquiryAnswer>();
        config.NewConfig<RemoveInquiryAnswerRequest, RemoveInquiryAnswer>();
    }

    private void Response(TypeAdapterConfig config)
    {
        config.NewConfig<InquiryDto, InquiryResponse>();
        config.NewConfig<InquiryDto, SearchInquiriesResponse>()
            .Map(dest => dest.IsAnswered, src => src.Answer != null);

        config.NewConfig<InquiryFileDto, InquiryFileResponse>();
    }
}
