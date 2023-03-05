using System.Net;

namespace OfficeRetro.Shared.Exceptions.Auth;

public abstract class AuthException : Exception, IServiceException
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

    public string ErrorMessage { get; set; } = string.Empty;

    public AuthException(string message)
    {
        ErrorMessage = $"AuthException: {message}";
    }

    public AuthException(string message, HttpStatusCode statusCode)
    {
        ErrorMessage = $"AuthException: {message}";
        StatusCode = statusCode;
    }
}
