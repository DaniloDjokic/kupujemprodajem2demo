using System.Diagnostics;
using KupujemProdajemClone.DataLayer;
using Microsoft.AspNetCore.Mvc;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;

namespace KupujemProdajemClone.Controllers;

public class HomeController(IProductService productService, IAuthService authService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var userId = authService.GetUserId(User.Identity);

        var userProducts = (await productService.GetProductsByUserAsync(userId)).Select(ProductViewModel.FromProduct).ToList();
        var products = (await productService.GetProductsAsync()).Select(ProductViewModel.FromProduct).ToList();
        var userRatings = (await productService.GetProductRatingByUserAsync(userId)).Select(RatingViewModel.FromRating).ToList();

        var viewModel = new HomeViewModel()
        {
            UserProducts = userProducts,
            Products = products,
            ProductRatings = userRatings,
        };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}