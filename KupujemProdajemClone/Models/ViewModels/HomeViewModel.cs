namespace KupujemProdajemClone.Models.ViewModels;

public class HomeViewModel
{
    public IReadOnlyCollection<ProductViewModel>? Products { get; set; } = [];
    public IReadOnlyCollection<ProductViewModel> UserProducts { get; set; } = [];
    public IReadOnlyCollection<RatingViewModel> ProductRatings { get; set; } = [];
}