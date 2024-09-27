using KupujemProdajemClone.DataLayer;
using KupujemProdajemClone.Models;

namespace KupujemProdajemClone.Services;

public class UserService(KupujemProdajemCloneContext context) : IUserService
{
    public User GetUser()
    {
        return context.Users.FirstOrDefault()!;
    }
}