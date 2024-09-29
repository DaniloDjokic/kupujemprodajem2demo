using KupujemProdajemClone.Models;

namespace KupujemProdajemClone.Services;

public interface IUserService
{
    Task<User?> GetUser(string username);
    Task<User> GetAuthenticatedUser(LoginViewModel loginViewModel);
}