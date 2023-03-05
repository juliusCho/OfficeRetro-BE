using OfficeRetro.Application.Inquiry.Exceptions;
using OfficeRetro.Domain.Inquiry.Factories.Interfaces;
using OfficeRetro.Domain.Inquiry.Repositories;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands.Handlers;

public class CreateInquiryHandler : ICommandHandler<CreateInquiry>
{
    private readonly IInquiryRepository _repository;
    private readonly IInquiryFactory _factory;

    public CreateInquiryHandler(
        IInquiryRepository repository,
        IInquiryFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public async Task HandleAsync(CreateInquiry command)
    {
        var inquiry = _factory.Create(
            command.Key,
            command.Writer,
            command.Title,
            command.Content,
            command.Password,
            command.Files);

        var existingInquiry = await _repository.GetAsync(inquiry.Key);

        if (existingInquiry is not null)
        {
            throw new InquiryExistsException(inquiry.Key);
        }

        await _repository.CreateAsync(inquiry);
    }
}
