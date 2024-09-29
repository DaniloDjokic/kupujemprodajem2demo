using System.ComponentModel.DataAnnotations;

namespace KupujemProdajemClone.Models.ViewModels;

public class RatingViewModel
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    [Required]
    [AllowedValues(1,2,3,4,5)]
    public int RatingValue { get; set; }

    public static RatingViewModel FromRating(Rating rating)
    {
        return new RatingViewModel
        {
            UserId = rating.UserId ?? 0,
            RatingValue = rating.RatingValue,
            ProductId = rating.ProductId
        };
    }
}