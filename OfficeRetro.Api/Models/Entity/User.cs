using System.ComponentModel.DataAnnotations;

namespace OfficeRetro.Models.Entity;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime RefreshTokenExpiryTime { get; set; }
}
