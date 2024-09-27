using KupujemProdajemClone.Models;

namespace KupujemProdajemClone.Services;

public interface IProductService
{
    Task<IReadOnlyCollection<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(int id, Product product);
    Task DeleteProductAsync(int productId, int userId);
    Task RateProductAsync(int productId, int userId, int rating);
}