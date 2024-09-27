using System.ComponentModel.DataAnnotations;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class ProductController(IProductService productService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddNewProduct(ProductViewModel model)
    {
        try
        {
            //save image file then set the path
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                // UserId = this.Cookie.UserId,
                Price = model.Price
            };

            await productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(AddNewProduct), model);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductViewModel model)
    {
        try
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
            };

            await productService.UpdateProductAsync(id, product);

            return NoContent();
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            //get userId from cookie
            await productService.DeleteProductAsync(id, 1);
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
        catch (InvalidDeleteException e)
        {
            return Forbid();
        }
    }

    [HttpPost("rate/{id}")]
    public async Task<IActionResult> RateProduct(int id, int ratingValue)
    {
        try
        {
            //get user id
            await productService.RateProductAsync(id, 1, ratingValue);
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
        catch (InvalidDeleteException e)
        {
            return Forbid();
        }
    }
}