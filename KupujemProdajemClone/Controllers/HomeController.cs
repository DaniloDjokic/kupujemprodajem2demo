using System.Diagnostics;
using KupujemProdajemClone.DataLayer;
using Microsoft.AspNetCore.Mvc;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;

namespace KupujemProdajemClone.Controllers;

public class HomeController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeViewModel()
        {
            Products = await productService.GetProductsAsync()
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