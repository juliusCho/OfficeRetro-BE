namespace OfficeRetro.Domain.Helpers.Validators;

public static class UrlValidator
{
    public static bool IsValid(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) return false;

        if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            return uri is not null &&
                (uri.Scheme.Equals(Uri.UriSchemeHttp) || uri.Scheme.Equals(Uri.UriSchemeHttps));
        }

        return false;
    }
}
