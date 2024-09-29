using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupujemProdajemClone.Models;

[Table("Users")]
public class User
{
    [Key] public int Id { get; set; }

    [MaxLength(100)] public string Username { get; set; } = string.Empty;

    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)] public string LastName { get; set; } = string.Empty;

    [MaxLength(100)] public string Email { get; set; } = string.Empty;

    [MaxLength(2000)] public string PasswordHash { get; set; } = string.Empty;

    public ICollection<Product> SellingProducts { get; set; } = [];
    public ICollection<Rating> Ratings { get; set; } = [];
}