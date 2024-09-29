using System.Security.Claims;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class UsersController(IUserService userService, IAuthService authService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var user = await userService.GetUser(HttpContext.User.Identity?.Name ?? string.Empty);

        if (user == null)
        {
            return Unauthorized();
        }

        var model = UserViewModel.FromUser(user);
        return View(model);
    }

    [HttpGet]
    public IActionResult LogIn([FromQuery] string returnUrl)
    {
        var model = new LoginViewModel() { ReturnUrl = returnUrl };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogIn([FromForm] LoginViewModel credentials, [FromQuery] string returnUrl)
    {
        credentials.ReturnUrl = returnUrl;
        if (!ModelState.IsValid)
        {
            return View(credentials);
        }

        try
        {
            var props = await authService.CreateLoginProperties(credentials, returnUrl);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                props.Item1, props.Item2);

            return Redirect(returnUrl);
        }
        catch (UserNotFoundException e)
        {
            ModelState.AddModelError(nameof(credentials.AreCredentialsValid), e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            ModelState.AddModelError(nameof(credentials.AreCredentialsValid), e.Message);
        }

        return View(credentials);
    }

    [HttpPost]
    public async Task<IActionResult> LogOut([FromQuery] string returnUrl)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return LocalRedirect($"/Users/LogIn?returnUrl={returnUrl}");
    }
}