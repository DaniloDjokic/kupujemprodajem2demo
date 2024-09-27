namespace KupujemProdajemClone.Exceptions;

public class InvalidRatingException : Exception
{
    public InvalidRatingException() {}
    public InvalidRatingException(string message) : base(message) {}
    public InvalidRatingException(string message, Exception inner) : base(message, inner) {}
}