using System.Net;

namespace OfficeRetro.Shared.Exceptions;

public class BadParamException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage { get; set; } = string.Empty;

    public BadParamException(string errorMessage)
    {
        ErrorMessage = $"BadParamException: {errorMessage}";
    }
}
