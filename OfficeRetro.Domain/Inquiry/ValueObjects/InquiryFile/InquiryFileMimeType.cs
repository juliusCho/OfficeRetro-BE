using OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;
using System.Net.Mime;

namespace OfficeRetro.Domain.Inquiry.ValueObjects.InquiryFile;

public record InquiryFileMimeType
{
    public string Value { get; }

    public InquiryFileMimeType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InquiryFileMimeTypeNullException();
        }

        if (!IsValidMimeType(value))
        {
            throw new InquiryFileMimeTypeInvalidException();
        }

        Value = value;
    }

    public static implicit operator string(InquiryFileMimeType inquiryFileMimeType)
        => inquiryFileMimeType.Value;

    public static explicit operator InquiryFileMimeType(string value)
        => new(value);

    private bool IsValidMimeType(string value)
    {
        var media = typeof(MediaTypeNames).GetProperties();
        if (media is null || !media.Any()) return true;

        var result = false;

        foreach (var medium in media)
        {
            if (medium is null) continue;

            var types = medium.GetType().GetProperties();
            if (types is null || !types.Any()) continue;
#nullable disable
            if (types.Any(t => t.GetValue(medium) is not null && 
                t.GetValue(medium).Equals(value)))
#nullable restore
            {
                result = true;
                break;
            }
        }

        return result;
    }
}
