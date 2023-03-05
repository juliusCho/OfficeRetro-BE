//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using OfficeRetro.Helpers;
//using OfficeRetro.Models.Dto;
//using Swashbuckle.AspNetCore.Annotations;
//using System.Globalization;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace OfficeRetro.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//[Consumes("application/json")]
//[Produces("application/json")]
//public class AuthController : ControllerBase
//{
//    private readonly AppDbContext _context;

//    public AuthController(AppDbContext context)
//    {
//        _context = context;
//    }

//    [HttpPost("authenticate")]
//    [SwaggerResponse(StatusCodes.Status200OK)]
//    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Common.BAD_PARAM)]
//    [SwaggerResponse(StatusCodes.Status404NotFound, InvalidMessages.Login.NO_EMAIL)]
//    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Login.PW_INCORRECT)]
//    public async Task<IActionResult> Authenticate([FromBody] UserDto loginInfo)
//    {
//        if (
//            loginInfo is null || 
//            string.IsNullOrWhiteSpace(loginInfo.Email) || 
//            string.IsNullOrWhiteSpace(loginInfo.Password))
//        {
//            return BadRequest(InvalidMessages.Common.BAD_PARAM);
//        }

//        var user = await _context.Users
//            .FirstOrDefaultAsync(u => u.Email.Equals(loginInfo.Email));

//        if (user is null) return NotFound(new { Message = InvalidMessages.Login.NO_EMAIL });

//        if (!PasswordHasher.VerifyPassword(loginInfo.Password, user.Password))
//        {
//            return BadRequest(new { Message = InvalidMessages.Login.PW_INCORRECT });
//        }

//        var tokenApi = new TokenApiDto
//        {
//            AccessToken = CreateJwt(user),
//            RefreshToken = await CreateRefreshToken()
//        };

//        user.Token = tokenApi.AccessToken;
//        user.RefreshToken = tokenApi.RefreshToken;
//        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(2);

//        await _context.SaveChangesAsync();

//        return Ok(tokenApi);
//    }

//    [HttpPost("register")]
//    [SwaggerResponse(StatusCodes.Status200OK)]
//    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Common.BAD_PARAM)]
//    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Signup.INVALID_EMAIL)]
//    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Signup.WEAK_PW)]
//    [SwaggerResponse(StatusCodes.Status409Conflict, InvalidMessages.Signup.EMAIL_EXISTS)]
//    public async Task<IActionResult> RegisterUser([FromBody] UserDto signupInfo)
//    {
//        if (
//            signupInfo is null || 
//            string.IsNullOrWhiteSpace(signupInfo.Email) || 
//            string.IsNullOrWhiteSpace(signupInfo.Password) ||
//            string.IsNullOrEmpty(signupInfo.FirstName) ||
//            string.IsNullOrEmpty(signupInfo.LastName))
//        {
//            return BadRequest(InvalidMessages.Common.BAD_PARAM);
//        }

//        if (!IsValidEmail(signupInfo.Email)) return BadRequest(InvalidMessages.Signup.INVALID_EMAIL);
//        if (!IsStrongPassword(signupInfo.Password)) return BadRequest(InvalidMessages.Signup.WEAK_PW);

//        signupInfo.Password = PasswordHasher.EncryptPassword(signupInfo.Password);
//        signupInfo.Role = "User";
//        signupInfo.Token = "";

//        var user = await _context.Users.AsNoTracking()
//            .FirstOrDefaultAsync(u => u.Email.Equals(signupInfo.Email));

//        if (user is not null) return Conflict(new { Message = InvalidMessages.Signup.EMAIL_EXISTS });

//        await _context.Users.AddAsync(signupInfo);
//        await _context.SaveChangesAsync();

//        return Ok();
//    }

//    [HttpPost("refresh")]
//    [SwaggerResponse(StatusCodes.Status200OK)]
//    [SwaggerResponse(StatusCodes.Status400BadRequest, InvalidMessages.Common.BAD_PARAM)]
//    [SwaggerResponse(StatusCodes.Status403Forbidden, InvalidMessages.Auth.INVALID_TOKEN)]
//    [SwaggerResponse(StatusCodes.Status401Unauthorized, InvalidMessages.Auth.TOKEN_EXPIRED)]
//    public async Task<IActionResult> RefreshToken(TokenApiDto tokenApi)
//    {
//        if (
//            tokenApi is null ||
//            string.IsNullOrWhiteSpace(tokenApi.AccessToken) ||
//            string.IsNullOrWhiteSpace(tokenApi.RefreshToken)) 
//        {
//            return BadRequest(InvalidMessages.Common.BAD_PARAM);
//        }

//        var principal = GetPrincipalFromExpiredToken(tokenApi.AccessToken);
//        var name = principal.Identity?.Name;
        
//        if (string.IsNullOrWhiteSpace(name)) return Forbid(InvalidMessages.Auth.INVALID_TOKEN);

//        var nameClaimSeparator = "|OfficeRetroNameClaimSeparator|";
//        var firstNameEndAt = name.IndexOf(nameClaimSeparator);
//        var lastNameStartAt = name.IndexOf(nameClaimSeparator) + nameClaimSeparator.Length;

//        var firstName = name.Substring(0, firstNameEndAt);
//        var lastName = name.Substring(lastNameStartAt);

//        var user = await _context.Users.FirstOrDefaultAsync(user => user.FirstName.Equals(firstName) && user.LastName.Equals(lastName));
//        if (user is null || !user.RefreshToken.Equals(tokenApi.RefreshToken))
//        {
//            return Forbid(InvalidMessages.Auth.INVALID_TOKEN);
//        }

//        if (user.RefreshTokenExpiryTime <= DateTime.UtcNow) return Unauthorized(InvalidMessages.Auth.TOKEN_EXPIRED);

//        var newTokenApi = new TokenApiDto
//        {
//            AccessToken = CreateJwt(user),
//            RefreshToken = await CreateRefreshToken()
//        };

//        user.Token = newTokenApi.AccessToken;
//        user.RefreshToken = newTokenApi.RefreshToken;

//        await _context.SaveChangesAsync();

//        return Ok(newTokenApi);
//    }

//    private string CreateJwt(UserDto user)
//    {
//        var jwtTokenHandler = new JwtSecurityTokenHandler();

//        var key = Encoding.ASCII.GetBytes("IamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongest");

//        var identity = new ClaimsIdentity(new Claim[]
//        {
//            new Claim(ClaimTypes.Role, user.Role),
//            new Claim(ClaimTypes.Name, $"{user.FirstName}|OfficeRetroNameClaimSeparator|{user.LastName}")
//        });

//        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);

//        var tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Subject = identity,
//            Expires = DateTime.UtcNow.AddMinutes(10),
//            SigningCredentials = credentials
//        };

//        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

//        return jwtTokenHandler.WriteToken(token);
//    }

//    private async Task<string> CreateRefreshToken()
//    {
//        var tokenBytes = RandomNumberGenerator.GetBytes(128);

//        var refreshToken = Convert.ToBase64String(tokenBytes);

//        var isMatchingUserExist = await _context.Users.AsNoTracking().AnyAsync(user => user.RefreshToken.Equals(refreshToken));

//        if (isMatchingUserExist) return await CreateRefreshToken();

//        return refreshToken;
//    }

//    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
//    {
//        var tokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("IamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongest")),
//            ValidateAudience = false,
//            ValidateIssuer = false,
//            ClockSkew = TimeSpan.Zero,
//            ValidateLifetime = false
//        };

//        var tokenHandler = new JwtSecurityTokenHandler();

//        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

//        var jwtSecurityToken = (JwtSecurityToken)securityToken;

//        if (
//            jwtSecurityToken is null || 
//            !jwtSecurityToken.Header.Alg.Equals(
//                SecurityAlgorithms.HmacSha512Signature, 
//                StringComparison.InvariantCulture))
//        {
//            throw new SecurityTokenException("Invalid token was received");
//        }

//        return principal;
//    }

//    private bool IsValidEmail(string email)
//    {
//        if (string.IsNullOrWhiteSpace(email)) return false;

//        try
//        {
//            email = Regex.Replace(
//                email, 
//                @"(@)(.+)$", 
//                match =>
//                {
//                    var idn = new IdnMapping();

//                    string domainName = idn.GetAscii(match.Groups[2].Value);
                     
//                    return match.Groups[1].Value + domainName;
//                },
//                RegexOptions.None, 
//                TimeSpan.FromMilliseconds(200));
//        }
//        catch (RegexMatchTimeoutException)
//        {
//            return false;
//        }
//        catch (ArgumentException)
//        {
//            return false;
//        }

//        try
//        {
//            return Regex.IsMatch(
//                email,
//                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
//                RegexOptions.IgnoreCase, 
//                TimeSpan.FromMilliseconds(250));
//        }
//        catch (RegexMatchTimeoutException)
//        {
//            return false;
//        }
//    }

//    private bool IsStrongPassword(string password)
//    {
//        if (string.IsNullOrWhiteSpace(password)) return false;

//        return Regex.IsMatch(
//            password,
//            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*\\\/\(\)\-__+\.\[\]\'\""\{\}\;\:\?\<\>\,\=\`\~\|])(?=.{8,})",
//            RegexOptions.IgnorePatternWhitespace,
//            TimeSpan.FromMilliseconds(200));
//    }
//}
