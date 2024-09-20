using System.Diagnostics;
using KupujemProdajemClone.DataLayer;
using Microsoft.AspNetCore.Mvc;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;

namespace KupujemProdajemClone.Controllers;

public class HomeController(KupujemProdajemCloneContext context) : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel()
        {
            Products = context.Products.ToList(),
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