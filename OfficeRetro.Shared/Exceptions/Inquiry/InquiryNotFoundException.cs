namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class AuthNotFoundException : InquiryException
{
    public AuthNotFoundException(string message) 
        : base(
            $"[NotFoundException] {message}",
            System.Net.HttpStatusCode.NotFound) { }
}
