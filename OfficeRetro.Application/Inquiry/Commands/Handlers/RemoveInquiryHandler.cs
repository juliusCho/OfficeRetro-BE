using OfficeRetro.Application.Inquiry.Exceptions;
using OfficeRetro.Domain.Inquiry.Repositories;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;

namespace OfficeRetro.Application.Inquiry.Commands.Handlers;

public class RemoveInquiryHandler : ICommandHandler<RemoveInquiry>
{
    private readonly IInquiryRepository _repository;

    public RemoveInquiryHandler(IInquiryRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveInquiry command)
    {
        var existingInquiry = await _repository.GetAsync(command.Key);
        if (existingInquiry is null)
        {
            throw new InquiryNotExistsException(command.Key);
        }

        await _repository.DeleteAsync(existingInquiry);
    }
}
