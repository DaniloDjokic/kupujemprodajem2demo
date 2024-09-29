using System.ComponentModel.DataAnnotations;

namespace KupujemProdajemClone.Models;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; } = String.Empty;
    [Required]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = String.Empty;

    public string ReturnUrl { get; set; } = string.Empty;

    public bool AreCredentialsValid { get; set; } = true;
}