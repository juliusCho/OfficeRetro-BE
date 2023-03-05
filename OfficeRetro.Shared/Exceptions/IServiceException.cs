using System.Net;

namespace OfficeRetro.Shared.Exceptions;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
