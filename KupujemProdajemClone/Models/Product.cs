namespace KupujemProdajemClone.Models;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string ImageSrc { get; set; } = string.Empty;
    public int UserId { get; set; }
}