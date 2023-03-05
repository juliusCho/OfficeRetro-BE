namespace OfficeRetro.Application.Auth.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(string token);
}
