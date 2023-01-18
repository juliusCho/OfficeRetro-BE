using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OfficeRetro.Context;
using OfficeRetro.Controllers.Constants;
using OfficeRetro.Helpers;
using OfficeRetro.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace OfficeRetro.Controllers;

[Route("api/[controller]")]
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("authenticate")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Common.BAD_PARAM)]
    [SwaggerResponse(StatusCodes.Status404NotFound, InvalidMessages.Login.NO_EMAIL)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, InvalidMessages.Login.PW_INCORRECT)]
    public async Task<IActionResult> Authenticate([FromBody] User loginInfo)
    {
        if (
            loginInfo is null || 
            string.IsNullOrWhiteSpace(loginInfo.Email) || 
            string.IsNullOrWhiteSpace(loginInfo.Password))
        {
            return BadRequest(InvalidMessages.Common.BAD_PARAM);
        }

        var user = await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(loginInfo.Email));

        if (user is null) return NotFound(new { Message = InvalidMessages.Login.NO_EMAIL });

        if (!PasswordHasher.VerifyPassword(loginInfo.Password, user.Password))
        {
            return Unauthorized(new { Message = InvalidMessages.Login.PW_INCORRECT });
        }

        return Ok(new {Token = CreateJwt(user) });
    }

    [HttpPost("register")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Common.BAD_PARAM)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Signup.INVALID_EMAIL)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Signup.WEAK_PW)]
    [SwaggerResponse(StatusCodes.Status409Conflict, InvalidMessages.Signup.EMAIL_EXISTS)]
    public async Task<IActionResult> RegisterUser([FromBody] User signupInfo)
    {
        if (
            signupInfo is null || 
            string.IsNullOrWhiteSpace(signupInfo.Email) || 
            string.IsNullOrWhiteSpace(signupInfo.Password) ||
            string.IsNullOrEmpty(signupInfo.FirstName) ||
            string.IsNullOrEmpty(signupInfo.LastName))
        {
            return BadRequest(InvalidMessages.Common.BAD_PARAM);
        }

        if (!IsValidEmail(signupInfo.Email)) return BadRequest(InvalidMessages.Signup.INVALID_EMAIL);
        if (!IsStrongPassword(signupInfo.Password)) return BadRequest(InvalidMessages.Signup.WEAK_PW);

        signupInfo.Password = PasswordHasher.EncryptPassword(signupInfo.Password);
        signupInfo.Role = "User";
        signupInfo.Token = "";

        var user = await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(signupInfo.Email));

        if (user is not null) return Conflict(new { Message = InvalidMessages.Signup.EMAIL_EXISTS });

        await _context.Users.AddAsync(signupInfo);
        await _context.SaveChangesAsync();

        return Ok();
    }

    private string CreateJwt(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes("IamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongest");

        var identity = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Name, user.LastName),
            new Claim(ClaimTypes.GivenName, user.FirstName)
        });

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;

        try
        {
            email = Regex.Replace(
                email, 
                @"(@)(.+)$", 
                DomainMapper,
                RegexOptions.None, 
                TimeSpan.FromMilliseconds(200));

            string DomainMapper(Match match)
            {
                var idn = new IdnMapping();

                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, 
                TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private bool IsStrongPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password)) return false;

        return Regex.IsMatch(
            password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*\\\/\(\)\-__+\.\[\]\'\""\{\}\;\:\?\<\>\,\=\`\~\|])(?=.{8,})",
            RegexOptions.IgnorePatternWhitespace,
            TimeSpan.FromMilliseconds(200));
    }
}
