using System.Security.Claims;
using System.Security.Principal;
using KupujemProdajemClone.Models;
using Microsoft.AspNetCore.Authentication;

namespace KupujemProdajemClone.Services;

public interface IAuthService
{
    Task<(ClaimsPrincipal, AuthenticationProperties)> CreateLoginProperties(LoginViewModel credentials,
        string returnUrl);

    public int GetUserId(IIdentity? identity);
}