using UrlShortener.Domain.Exceptions;

namespace UrlShortener.Domain.ValueObjects;

public sealed record ShortUrl
{
    public string Value { get; } 

    public ShortUrl(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidShortUrlException(value);
        }

        if (value.Length < 8 || value.Length > 15)
        {
            throw new InvalidShortUrlException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(ShortUrl shortUrl)
        => shortUrl.Value;

    public static implicit operator ShortUrl(string value)
        => new(value);
}