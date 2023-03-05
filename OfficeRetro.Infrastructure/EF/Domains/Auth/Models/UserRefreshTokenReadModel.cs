namespace OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

internal class UserRefreshTokenReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public string RefreshToken { get; }
    public DateTime ExpiryTime { get; }
    public DateTime CreatedAt { get; }
    public UserReadModel User { get; }
}
