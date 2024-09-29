using System.Security.Principal;
using KupujemProdajemClone.DataLayer;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Utils;
using Microsoft.EntityFrameworkCore;

namespace KupujemProdajemClone.Services;

public class ProductService(KupujemProdajemCloneContext context, IAuthService authService) : IProductService
{
    public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
    {
        return await context.Products.Include(x => x.Ratings).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await context.Products.Include(x => x.Ratings).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateProductAsync(IIdentity? identity, ProductViewModel model)
    {
        string imageSource = await SaveImage(model.ImageData);

        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            UserId = authService.GetUserId(identity),
            Price = model.Price,
            ImageSrc = imageSource,
        };

        await context.Products.AddAsync(product);

        await context.SaveChangesAsync();
    }

    private async Task<string> SaveImage(IFormFile? imageData)
    {
        if (imageData is null) return string.Empty;

        var imgNameHash = Crypto.CalculateMd5Hash(imageData.FileName);
        var fileExtension = Path.GetExtension(imageData.FileName);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\imgs", $"{imgNameHash}{fileExtension}");
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await imageData.CopyToAsync(fileStream);

        return $"/imgs/{imgNameHash}{fileExtension}";

    }

    public async Task UpdateProductAsync(int id, ProductViewModel model)
    {
        var oldProduct = await GetProductByIdAsync(id);

        if (oldProduct == null)
            throw new ProductNotFoundException($"Product {id} not found");

        string imageSource = await SaveImage(model.ImageData);

        oldProduct.Name = model.Name;
        oldProduct.Price = model.Price;
        oldProduct.Description = model.Description;
        oldProduct.ImageSrc = imageSource;

        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int productId, int userId)
    {
        var product = await GetProductByIdAsync(productId);

        if (product == null)
            throw new ProductNotFoundException($"Product {productId} not found");

        if (product.UserId != userId)
            throw new InvalidDeleteException($"User {userId} not authorized to delete product");

        context.Products.Remove(product);

        await context.SaveChangesAsync();
    }

    public async Task RateProductAsync(int productId, int userId, int rating)
    {
        var product = await GetProductByIdAsync(productId);

        if (product == null)
            throw new ProductNotFoundException($"Product {productId} not found");

        if (product.Ratings.Any(x => x.UserId == userId))
            throw new InvalidRatingException($"User {userId} rating already exists");

        product.Ratings.Add(new Rating { UserId = userId, RatingValue = rating });

        await context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Product>> GetProductsByUserAsync(int userId)
    {
        return await context.Products.Include(x => x.Ratings).Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<IReadOnlyCollection<Rating>> GetProductRatingByUserAsync(int userId)
    {
        return await context.Ratings.Where(x => x.UserId == userId).ToListAsync();
    }
}