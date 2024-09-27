namespace KupujemProdajemClone.Models.ViewModels;

public class ProductViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
}