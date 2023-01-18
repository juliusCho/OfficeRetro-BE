namespace OfficeRetro.Controllers.Constants;

public static class InvalidMessages
{
    public record Common
    {
        public const string BAD_PARAM = "Valid information is required";
    }

    public record Login
    {
        public const string NO_EMAIL = "The email was not registered";
        public const string PW_INCORRECT = "Password is incorrect";
    }

    public record Signup
    {
        public const string INVALID_EMAIL = "Email has invalid format";
        public const string WEAK_PW = "Password is weak";
        public const string EMAIL_EXISTS = "The email was already registered";
    }
}
