using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeRetro.Application.Inquiry.Commands;
using OfficeRetro.Application.Inquiry.Queries;
using OfficeRetro.Contracts.Inquiry.Request;
using OfficeRetro.Contracts.Inquiry.Response;
using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Transactions.Commands.Interfaces;
using OfficeRetro.Shared.Transactions.Queries.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace OfficeRetro.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class InquiryController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IMapper _mapper;

    public InquiryController(
        ICommandDispatcher commandDispatcher, 
        IQueryDispatcher queryDispatcher,
        IMapper mapper)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _mapper = mapper;
    }

    [HttpGet("{key:guid}/{password}")]
    //[Authorize]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, InquiryExceptionMessages.NOT_FOUND)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_PASSWORD)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.PASSWORD_WEAK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.PASSWORD_INCORRECT)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<InquiryResponse>> Get([FromRoute] GetInquiryRequest request)
    {
        var query = _mapper.Map<GetInquiry>(request);

        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(_mapper.Map<InquiryResponse>(result));
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_WRITER)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.WRITER_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_TITLE)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.TITLE_MAX)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<SearchInquiriesResponse>>> Get(
        [FromQuery] SearchInquiriesRequest request)
    {
        var query = _mapper.Map<SearchInquiries>(request);

        var result = await _queryDispatcher.QueryAsync(query);

        if (!result.Any()) return NoContent();

        return Ok(result.Select(_mapper.Map<SearchInquiriesResponse>));
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_WRITER)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.WRITER_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_TITLE)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.TITLE_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_CONTENT)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.CONTENT_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_PASSWORD)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.PASSWORD_WEAK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.EMPTY_URL)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.URL_INVALID)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.URL_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.EMPTY_MIME_TYPE)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.MIME_TYPE_INVALID)]
    [SwaggerResponse(StatusCodes.Status409Conflict, InquiryExceptionMessages.ALREADY_EXISTS)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CreateInquiryRequest request)
    {
        var command = _mapper.Map<CreateInquiry>(request);

        await _commandDispatcher.CommandAsync(command);

        return CreatedAtAction(nameof(Get), new { command.Key }, command);
    }

    [HttpPut]
    [SwaggerResponse(StatusCodes.Status202Accepted)]
    [SwaggerResponse(StatusCodes.Status404NotFound, InquiryExceptionMessages.NOT_FOUND)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_WRITER)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.WRITER_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_TITLE)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.TITLE_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_CONTENT)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.CONTENT_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.EMPTY_PASSWORD)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.PASSWORD_WEAK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.EMPTY_URL)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.URL_INVALID)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.URL_MAX)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.EMPTY_MIME_TYPE)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InquiryExceptionMessages.File.MIME_TYPE_INVALID)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] UpdateInquiryRequest request)
    {
        var command = _mapper.Map<UpdateInquiry>(request);

        await _commandDispatcher.CommandAsync(command);

        return AcceptedAtAction(nameof(Get), new { key = command.Key }, command);
    }

    [HttpDelete("{key:guid}/{password}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, InquiryExceptionMessages.NOT_FOUND)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete([FromRoute] RemoveInquiryRequest request)
    {
        var command = _mapper.Map<RemoveInquiry>(request);

        await _commandDispatcher.CommandAsync(command);

        return Ok();
    }
}
