using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;

namespace KupujemProdajemClone.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel()
        {
            Products = GetProducts()
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

    private List<Product> GetProducts()
    {
        return
        [
            new Product()
            {
                Name = "Test Name1",
                Description = "Test Description1",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name1",
                Description = "Test Description1",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name1",
                Description = "Test Description1",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name1",
                Description = "Test Description1",
                Price = 1000.10m,
                Rating = 3,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test Description2",
                Price = 11000.10m,
                Rating = 5,
                ImageSrc = "/imgs/stock.jpg"
            },
        ];
    }
}