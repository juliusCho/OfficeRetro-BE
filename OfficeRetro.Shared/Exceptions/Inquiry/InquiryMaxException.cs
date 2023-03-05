namespace OfficeRetro.Shared.Exceptions.Inquiry;

public abstract class AuthMaxException : InquiryException
{
    public AuthMaxException(string message, ushort length) 
        : base(
            $"[MaxException] {message} {length}",
            System.Net.HttpStatusCode.BadRequest) { }
}

