﻿namespace UrlShortener.Domain.ValueObjects;

public sealed record UrlId
{
    public Guid Value { get; }

    public UrlId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new Exception("Guid is empty");
        }

        Value = value;
    }

    public static UrlId Create() => new(Guid.NewGuid());
    
    public static implicit operator Guid(UrlId urlId)
        => urlId.Value;

    public static implicit operator UrlId(Guid value)
        => new(value);
}