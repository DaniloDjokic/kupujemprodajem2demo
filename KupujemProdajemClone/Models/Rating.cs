using System.ComponentModel.DataAnnotations;

namespace KupujemProdajemClone.Models;

public class Rating
{
    [Key] public int Id { get; set; }
    public int RatingValue { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int? UserId { get; set; }
    public User? User { get; set; }
}