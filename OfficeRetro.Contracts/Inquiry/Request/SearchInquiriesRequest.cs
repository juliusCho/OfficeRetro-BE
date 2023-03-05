namespace OfficeRetro.Contracts.Inquiry.Request;

public record SearchInquiriesRequest(
    string? Writer,
    string? Title,
    DateTime? StartAt,
    DateTime? EndAt);
