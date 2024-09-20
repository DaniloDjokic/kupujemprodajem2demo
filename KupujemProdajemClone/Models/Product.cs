using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KupujemProdajemClone.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KupujemProdajemClone.Models;

[Table("Products")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Precision(10,2)]
    public decimal Price { get; set; }

    public int Rating { get; set; }

    [MaxLength(1000)]
    public string ImageSrc { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}