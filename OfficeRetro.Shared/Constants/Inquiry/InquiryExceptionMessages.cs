namespace OfficeRetro.Shared.Constants.Inquiry;

public record InquiryExceptionMessages
{
    public const string NOT_FOUND = "Inquiry is not found";
    public const string EMPTY_WRITER = "Writer is empty";
    public const string WRITER_MAX = "Writer cannot be longer than";
    public const string EMPTY_TITLE = "Title is empty";
    public const string TITLE_MAX = "Title cannot be longer than";
    public const string EMPTY_CONTENT = "Content is empty";
    public const string CONTENT_MAX = "Content cannot be longer than";
    public const string EMPTY_PASSWORD = "Password is empty";
    public const string PASSWORD_WEAK = "Password is not strong enough";
    public const string ALREADY_EXISTS = "Inquiry already exists with the key of";
    public const string PASSWORD_INCORRECT = "Password is incorrect";

    public record File
    {
        public const string EMPTY_URL = "File Url is empty";
        public const string URL_INVALID = "File Url is invalid";
        public const string URL_MAX = "File Url cannot be longer than";
        public const string EMPTY_MIME_TYPE = "File MimeType is empty";
        public const string MIME_TYPE_INVALID = "File MimeType is invalid";
        public const string ALREADY_EXISTS = "File already exists";
    }

    public record Answer
    {
        public const string INVALID_USER = "Answer writer info is invalid";
        public const string USER_NO_PERMIT = "The writer does not have permission to write an answer";
        public const string EMPTY_TARGET = "Inquiry for answer is empty";
    }
}
