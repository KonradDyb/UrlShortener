namespace UrlShortener.Domain.Exceptions;

public sealed class InvalidOriginalUrlException : CustomException
{
    public InvalidOriginalUrlException(string urlId)
        : base($"Original urlId {urlId} is invalid.")
    {
    }
}