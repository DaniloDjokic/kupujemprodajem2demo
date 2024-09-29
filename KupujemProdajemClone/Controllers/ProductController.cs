using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class ProductController(IProductService productService, IAuthService authService) : Controller
{
    [HttpGet]
    public IActionResult NewProduct()
    {
        var model = new ProductViewModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> New(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("NewProduct", model);
        }

        try
        {
            //save image file then set the path
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                UserId = authService.GetUserId(User.Identity),
                Price = model.Price
            };

            await productService.CreateProductAsync(product);
            return RedirectToAction("Index", "Users");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> Update(int id, ProductViewModel model)
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
    public async Task<IActionResult> Delete(int id)
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
    public async Task<IActionResult> Rate(int id, int ratingValue)
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