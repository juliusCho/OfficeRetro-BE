namespace OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

internal class UserPasswordResetReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public ushort ResetConfirmCode { get; }
    public DateTime ExpiryTime { get; }
    public DateTime CreatedAt { get; }
    public UserReadModel User { get; }
}
