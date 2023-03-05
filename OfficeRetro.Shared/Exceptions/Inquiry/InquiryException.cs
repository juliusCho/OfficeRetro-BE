using System.Net;

namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class InquiryException : Exception, IServiceException
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

    public string ErrorMessage { get; set; } = string.Empty;

    public InquiryException(string message)
    {
        ErrorMessage = $"InquiryException: {message}";
    }

    public InquiryException(string message, HttpStatusCode statusCode)
    {
        ErrorMessage = $"InquiryException: {message}";
        StatusCode = statusCode;
    }
}
