using UrlShortener.Domain.Exceptions;

namespace UrlShortener.Domain.ValueObjects;

public sealed record OriginalUrl
{
    public string Value { get; } 

    public OriginalUrl(string value)
    {
        
        ValidateUrl(value);
        Value = value;
    }

    private void ValidateUrl(string value)
    {
        if (Uri.IsWellFormedUriString(value, UriKind.Absolute))
        {
            if (Uri.TryCreate(value, UriKind.Absolute, out Uri uriResult))
            {
                if (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                {
                    return;
                }

                throw new InvalidOriginalUrlSchemeException(value);
            }

            throw new InvalidOriginalUrlException(value);
        }

        throw new InvalidOriginalUrlException(value);
    }

    public static implicit operator string(OriginalUrl originalUrl)
        => originalUrl.Value;

    public static implicit operator OriginalUrl(string value)
        => new(value);
}