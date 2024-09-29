using System.Security.Principal;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;

namespace KupujemProdajemClone.Services;

public interface IProductService
{
    Task<IReadOnlyCollection<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task CreateProductAsync(IIdentity? identity, ProductViewModel model);
    Task UpdateProductAsync(int id, ProductViewModel model);
    Task DeleteProductAsync(int productId, int userId);
    Task RateProductAsync(int productId, int userId, int rating);
}