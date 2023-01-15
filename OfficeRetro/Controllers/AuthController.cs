using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeRetro.Context;
using OfficeRetro.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace OfficeRetro.Controllers;

[Route("api/[controller]")]
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private const string LOGIN_NO_EMAIL = "The email was not registered";
    private const string LOGIN_PW_INCORRECt = "Password is incorrect";

    private const string SIGNUP_EMAIL_EXISTS = "The email was already registered";

    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("authenticate")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound, LOGIN_NO_EMAIL)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, LOGIN_PW_INCORRECt)]
    public async Task<IActionResult> Authenticate([FromBody] User loginInfo)
    {
        if (loginInfo is null) return BadRequest();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(loginInfo.Email));
        if (user is null) return NotFound(new { Message = LOGIN_NO_EMAIL });
        
        if (!user.Password.Equals(loginInfo.Password)) return Unauthorized(new { Message = LOGIN_PW_INCORRECt });

        return Ok();
    }

    [HttpPost("register")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status409Conflict, SIGNUP_EMAIL_EXISTS)]
    public async Task<IActionResult> RegisterUser([FromBody] User signupInfo)
    {
        if (signupInfo is null) return BadRequest();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(signupInfo.Email));
        if (user is not null) return Conflict(new { Message = SIGNUP_EMAIL_EXISTS });

        await _context.Users.AddAsync(signupInfo);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
