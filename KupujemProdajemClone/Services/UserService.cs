using System.Security.Cryptography;
using System.Text;
using KupujemProdajemClone.DataLayer;
using KupujemProdajemClone.Exceptions;
using KupujemProdajemClone.Models;
using KupujemProdajemClone.Utils;
using Microsoft.EntityFrameworkCore;

namespace KupujemProdajemClone.Services;

public class UserService(KupujemProdajemCloneContext context) : IUserService
{
    public async Task<User?> GetUser(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User> GetAuthenticatedUser(LoginViewModel loginViewModel)
    {
        var user = await GetUser(loginViewModel.Username);

        if (user == null)
            throw new UserNotFoundException($"Could not find user {loginViewModel.Username}");

        var passwordHash = Crypto.CalculateSha256Hash(loginViewModel.Password);

        if (passwordHash != user.PasswordHash)
            throw new UnauthorizedAccessException($"Invalid username or password");

        return user;
    }
}