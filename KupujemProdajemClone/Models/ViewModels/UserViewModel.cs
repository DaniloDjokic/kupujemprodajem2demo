namespace KupujemProdajemClone.Models.ViewModels;

public class UserViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    public string FullName => $"{FirstName} {LastName}";

    public static UserViewModel FromUser(User user)
    {
        return new UserViewModel()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Products = user.SellingProducts.Select(ProductViewModel.FromProduct).ToList()
        };
    }
}