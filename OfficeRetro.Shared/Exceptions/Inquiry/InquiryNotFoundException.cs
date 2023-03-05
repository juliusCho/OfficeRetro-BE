namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class InquiryNotFoundException : InquiryException
{
    public InquiryNotFoundException(string message) 
        : base(
            $"[NotFoundException] {message}",
            System.Net.HttpStatusCode.NotFound) { }
}
