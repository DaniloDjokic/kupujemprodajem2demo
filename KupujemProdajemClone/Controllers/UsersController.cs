using KupujemProdajemClone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        var user = new User()
        {
            FirstName = "John",
            LastName = "Doe",
            Id = 1,
            Email = "johndoe@gmail.com",
            SellingProducts = []
        };
        var model = new UserViewModel(user);
        return View(model);
    }
}