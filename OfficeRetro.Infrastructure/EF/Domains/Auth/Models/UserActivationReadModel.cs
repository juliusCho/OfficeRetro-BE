namespace OfficeRetro.Infrastructure.EF.Domains.Auth.Models;

internal class UserActivationReadModel
{
    public long Id { get; }
    public Guid Key { get; }
    public ushort ActivatedCode { get; }
    public DateTime ExpiryTime { get; }
    public DateTime CreatedAt { get; }
    public UserReadModel User { get; }
}
