using System.Security.Claims;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Models.ViewModels;
using KupujemProdajemClone.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace KupujemProdajemClone.Controllers;

public class UsersController(IUserService userService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var user = await userService.GetUser(HttpContext.User.Identity?.Name ?? string.Empty);

        if (user == null)
        {
            return Unauthorized();
        }

        var model = new UserViewModel(user);
        return View(model);
    }

    [HttpGet]
    public IActionResult LogIn([FromQuery] string returnUrl)
    {
        var model = new LoginViewModel() {ReturnUrl = returnUrl};
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogIn([FromForm] LoginViewModel credentials, [FromQuery] string returnUrl)
    {
        try
        {
            var user = await userService.GetAuthenticatedUser(credentials);

            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.Username),
                new("Id", user.Id.ToString()),
                new("Username", user.Username)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var props = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow,
                RedirectUri = returnUrl
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), props);

            return Redirect(returnUrl);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Forbid(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> LogOut([FromQuery] string returnUrl)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return LocalRedirect($"/Users/LogIn?returnUrl={returnUrl}");
    }
}