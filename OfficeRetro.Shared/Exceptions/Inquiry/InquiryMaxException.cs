namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class InquiryMaxException : InquiryException
{
    public InquiryMaxException(string message, ushort length) 
        : base(
            $"[MaxException] {message} {length}",
            System.Net.HttpStatusCode.BadRequest) { }
}

