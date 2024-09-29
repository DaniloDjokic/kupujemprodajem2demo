using System.ComponentModel.DataAnnotations;
using KupujemProdajemClone.Attributes;

namespace KupujemProdajemClone.Models.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(0.09, int.MaxValue, ErrorMessage = "Price must be 0.1 or higher")]
    public decimal Price { get; set; }

    public string ImageName { get; set; } = string.Empty;

    [MaxFileSize(10 * 1024 * 1024)]
    [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")]
    public IFormFile? ImageData { get; set; }

    public string ImageSrc { get; set; } = string.Empty;
    public double TotalRating { get; set; }

    public static ProductViewModel FromProduct(Product product)
    {
        return new ProductViewModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageSrc = product.ImageSrc,
            TotalRating = product.TotalRating
        };
    }
}