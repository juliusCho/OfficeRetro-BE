namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class AuthNullException : InquiryException
{
    public AuthNullException(string message) 
        : base(
            $"[NullException] {message}",
            System.Net.HttpStatusCode.BadRequest) { }
}
