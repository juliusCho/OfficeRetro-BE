using System.Text.RegularExpressions;

namespace OfficeRetro.Domain.Helpers.Validators;

public static class PasswordValidator
{
    public static bool IsStrong(string password)
    {
        if (string.IsNullOrWhiteSpace(password)) return false;

        return Regex.IsMatch(
            password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*\\\/\(\)\-__+\.\[\]\'\""\{\}\;\:\?\<\>\,\=\`\~\|])(?=.{8,})",
            RegexOptions.IgnorePatternWhitespace,
            TimeSpan.FromMilliseconds(200));
    }
}
