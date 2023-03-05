using OfficeRetro.Shared.Enums.Auth;

namespace OfficeRetro.Domain.Auth.Entities;

public class User
{
    public long Id { get; }
    public Guid Key { get; private set; }
    public UserRole Role { get; private set; }
}
