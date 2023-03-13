namespace UrlShortener.Domain.Exceptions;

public sealed class InvalidOriginalUrlSchemeException : CustomException
{
    public InvalidOriginalUrlSchemeException(string urlId)
        : base($"The URL scheme {urlId} is invalid. The URL must start with 'http://' or 'https://'.")
    {
        
    }
}