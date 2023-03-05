using OfficeRetro.Application.Inquiry.Exceptions;
using OfficeRetro.Domain.Inquiry.Factories.Interfaces;
using OfficeRetro.Domain.Inquiry.Repositories;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands.Handlers;

public class UpdateInquiryHandler : ICommandHandler<UpdateInquiry>
{
    private readonly IInquiryRepository _repository;
    private readonly IInquiryFactory _factory;

    public UpdateInquiryHandler(
        IInquiryRepository repository,
        IInquiryFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public async Task HandleAsync(UpdateInquiry command)
    {
        var existingInquiry = await _repository.GetAsync(command.Key);
        if (existingInquiry is null)
        {
            throw new InquiryNotExistsException(command.Key);
        }

        existingInquiry.Update(
            command.Writer, 
            command.Title, 
            command.Content, 
            command.Password);

        existingInquiry.AddFiles(_factory.CreateFileCollection(command.Files));

        await _repository.UpdateAsync(existingInquiry);
    }
}
