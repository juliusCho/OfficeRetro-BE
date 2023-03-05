using System.Globalization;
using System.Text.RegularExpressions;

namespace OfficeRetro.Domain.Helpers.Validators;

public static class EmailValidator
{
    public static bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;

        try
        {
            email = Regex.Replace(
                email,
                @"(@)(.+)$",
                match =>
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                },
                RegexOptions.None,
                TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
