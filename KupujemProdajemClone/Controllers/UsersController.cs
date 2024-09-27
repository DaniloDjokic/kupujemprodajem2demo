using System.ComponentModel.DataAnnotations;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class UsersController(IUserService userService) : Controller
{
    public IActionResult Index()
    {
        var user = userService.GetUser();
        var model = new UserViewModel(user!);
        return View(model);
    }
}