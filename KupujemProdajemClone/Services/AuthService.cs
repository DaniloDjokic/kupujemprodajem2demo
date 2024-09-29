using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Principal;
using KupujemProdajemClone.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KupujemProdajemClone.Services;

public class AuthService(IUserService userService) : IAuthService
{
    public async Task<(ClaimsPrincipal, AuthenticationProperties)> CreateLoginProperties(LoginViewModel credentials,
        string returnUrl)
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

        return (new ClaimsPrincipal(identity), props);
    }

    public int GetUserId(IIdentity? identity)
    {
        var claims = (identity as ClaimsIdentity)?.Claims;

        if (claims == null) throw new AuthenticationException("No claims but user is authenticated?");

        var idClaim = claims.FirstOrDefault(x => x.Type == "Id");

        if (idClaim == null) throw new AuthenticationException("Cannot find claim with name 'Id'");

        if (int.TryParse(idClaim.Value, out int userId))
        {
            return userId;
        }

        throw new AuthenticationException("User Id cannot be converted to int");
    }
}