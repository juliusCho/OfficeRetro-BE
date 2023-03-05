namespace OfficeRetro.Shared.Exceptions.Auth;

public abstract class AuthMaxException : AuthException
{
    public AuthMaxException(string message, ushort length) 
        : base(
            $"[MaxException] {message} {length}",
            System.Net.HttpStatusCode.BadRequest) { }
}

