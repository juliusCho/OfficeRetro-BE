namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class InquiryNullException : InquiryException
{
    public InquiryNullException(string message) 
        : base(
            $"[NullException] {message}",
            System.Net.HttpStatusCode.BadRequest) { }
}
