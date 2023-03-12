namespace UrlShortener.Domain.ValueObjects;

public sealed record OriginalUrl
{
    public string Value { get; } 

    public OriginalUrl(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception(value);
        }
        
        Value = value;
    }

    public static implicit operator string(OriginalUrl originalUrl)
        => originalUrl.Value;

    public static implicit operator OriginalUrl(string value)
        => new(value);
}