namespace OfficeRetro.Shared.Exceptions.Auth;

public abstract class AuthNullException : AuthException
{
    public AuthNullException(string message) 
        : base(
            $"[NullException] {message}",
            System.Net.HttpStatusCode.BadRequest) { }
}
