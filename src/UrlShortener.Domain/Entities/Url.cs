using UrlShortener.Domain.ValueObjects;

namespace UrlShortener.Domain.Entities;

public class Url
{
    public UrlId Id { get;  }
    public OriginalUrl OriginalUrl { get; private set; }
    public ShortUrl ShortUrl { get; private set; }

    public Url(UrlId id, OriginalUrl originalUrl, ShortUrl shortUrl)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        OriginalUrl = originalUrl ?? throw new ArgumentNullException(nameof(originalUrl));
        ShortUrl = shortUrl ?? throw new ArgumentNullException(nameof(shortUrl));
    }
} 