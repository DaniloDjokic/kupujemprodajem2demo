namespace KupujemProdajemClone.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException() : base()
    {
    }

    public ProductNotFoundException(string message) : base(message)
    {
    }

    public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}