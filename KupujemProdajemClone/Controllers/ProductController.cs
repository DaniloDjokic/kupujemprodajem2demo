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

        await productService.CreateProductAsync(User.Identity, model);
        return RedirectToAction("MyAccount", "Users");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        var product = await productService.GetProductByIdAsync(id);

        if (product == null)
        {
            return new NotFoundResult();
        }

        var model = ProductViewModel.FromProduct(product);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, [FromForm]ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("UpdateProduct", model);
        }

        try
        {
            await productService.UpdateProductAsync(id, model);

            return RedirectToAction("MyAccount", "Users");
        }
        catch (ProductNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            int userId = authService.GetUserId(User.Identity);
            await productService.DeleteProductAsync(id, userId);
            return RedirectToAction("MyAccount", "Users");
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

    [HttpPost]
    public async Task<IActionResult> Rate(int id, int ratingValue)
    {
        try
        {
            int userId = authService.GetUserId(User.Identity);
            await productService.RateProductAsync(id, userId, ratingValue);
            return RedirectToAction("Index", "Home");
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