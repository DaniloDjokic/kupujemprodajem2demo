﻿using KupujemProdajemClone.DataLayer;
using KupujemProdajemClone.Exceptions;
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
        return await context.Products.Include(x => x.Ratings).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateProductAsync(Product product)
    {
        //try save image
        await context.Products.AddAsync(product);

        await context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(int id, Product product)
    {
        var oldProduct = await GetProductByIdAsync(id);

        if (oldProduct == null)
            throw new ProductNotFoundException($"Product {id} not found");

        //try save image

        oldProduct.Name = product.Name;
        oldProduct.Price = product.Price;
        oldProduct.Description = product.Description;
        oldProduct.ImageSrc = product.ImageSrc;

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

        product.Ratings.Add(new Rating{UserId = userId, RatingValue = rating});

        await context.SaveChangesAsync();
    }
}