using System.ComponentModel.DataAnnotations;

namespace OfficeRetro.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}
