namespace UrlShortener.Domain.Exceptions;

public sealed class InvalidShortUrlException : CustomException
{
    public InvalidShortUrlException(string shortUrl)
        : base($"Short Url {shortUrl} is invalid")
    {
    }
}