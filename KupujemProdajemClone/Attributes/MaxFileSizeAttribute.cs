using System.ComponentModel.DataAnnotations;

namespace KupujemProdajemClone.Attributes;

public class MaxFileSizeAttribute(int maxFileSize) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return ValidationResult.Success;

        if (value is byte[] file)
        {
            if (file.Length > maxFileSize)
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        return $"Maximum allowed file size is {maxFileSize} bytes.";
    }
}