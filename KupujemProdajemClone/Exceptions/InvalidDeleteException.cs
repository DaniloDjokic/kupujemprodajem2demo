namespace KupujemProdajemClone.Exceptions;

public class InvalidDeleteException : Exception
{
    public InvalidDeleteException() : base() { }
    public InvalidDeleteException(string message) : base(message) { }
    public InvalidDeleteException(string message, Exception innerException) : base(message, innerException) { }
}