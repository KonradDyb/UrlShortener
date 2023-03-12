namespace UrlShortener.Domain.Exceptions;

public sealed class InvalidEntityIdException : CustomException
{
    public InvalidEntityIdException(Guid urlId)
        : base($"Guid {urlId} is empty.")
    {
        
    }
}