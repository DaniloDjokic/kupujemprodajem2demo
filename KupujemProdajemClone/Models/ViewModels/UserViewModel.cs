namespace KupujemProdajemClone.Models.ViewModels;

public class UserViewModel(User user)
{
    public string FullName => $"{user.FirstName} {user.LastName}";
}