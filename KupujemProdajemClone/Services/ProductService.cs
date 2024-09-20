using KupujemProdajemClone.DataLayer;
using KupujemProdajemClone.Models;
using Microsoft.EntityFrameworkCore;

namespace KupujemProdajemClone.Services;

public class ProductService(KupujemProdajemCloneContext context) : IProductService
{
    public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
    {
        return await context.Products.Include(x => x.Ratings).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateProductAsync(Product product)
    {
        await context.Products.AddAsync(product);

        await context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(int id, Product product)
    {
        var oldProduct = await GetProductByIdAsync(id);

        if (oldProduct == null)
            throw new ArgumentException($"Product {id} not found");

        oldProduct.Name = product.Name;
        oldProduct.Price = product.Price;
        oldProduct.Description = product.Description;
        oldProduct.ImageSrc = product.ImageSrc;

        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await GetProductByIdAsync(id);

        if (product == null)
            throw new ArgumentException($"Product {id} not found");

        context.Products.Remove(product);

        await context.SaveChangesAsync();
    }
}