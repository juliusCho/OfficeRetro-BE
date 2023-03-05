namespace OfficeRetro.Shared.Exceptions.Auth;

public abstract class AuthNotFoundException : AuthException
{
    public AuthNotFoundException(string message) 
        : base(
            $"[NotFoundException] {message}",
            System.Net.HttpStatusCode.NotFound) { }
}
