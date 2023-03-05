using OfficeRetro.Infrastructure.EF.Domains.Inquiry.Models;

namespace OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

internal class UserReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public string Email { get; }
    public string Password { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public ushort Role { get; }
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; }
    public UserActivationReadModel? RefreshToken { get; }
    public UserActivationReadModel? Activation { get; }
    public UserPasswordResetReadModel? PasswordReset { get; }
    public IEnumerable<InquiryAnswerReadModel> InquiryAnswers { get; }
}
