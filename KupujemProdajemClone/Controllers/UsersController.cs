using KupujemProdajemClone.DataLayer;
using KupujemProdajemClone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class UsersController(KupujemProdajemCloneContext _context) : Controller
{
    public IActionResult Index()
    {
        var user = _context.Users.FirstOrDefault();
        var model = new UserViewModel(user!);
        return View(model);
    }
}