using System.ComponentModel.DataAnnotations;

namespace KupujemProdajemClone.Attributes;

public class AllowedExtensionsAttribute(params string[] extensions) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return ValidationResult.Success;

        if (value is string file)
        {
            var filetype = Path.GetExtension(file);

            if (!extensions.Contains(filetype))
            {
                return new ValidationResult("This file extension is not allowed!");
            }
        }

        return ValidationResult.Success;
    }
}