using System;
using Shouldly;
using UrlShortener.Domain.Exceptions;
using UrlShortener.Domain.ValueObjects;
using Xunit;

namespace UrlShortener.Domain.Tests.ValueObjects;

public class ShortUrlTests
{
    [Theory]
    [InlineData("abc123")]
    [InlineData("aBc1DeF2")]
    public void should_createshorturl(string value)
    {
        // Arrange & Act
        var shortUrl = new ShortUrl(value);

        // Assert
        shortUrl.Value.ShouldBe(value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("abc")]
    public void should_throw_invalidshorturlexception(string value)
    {
        // Arrange & Act
        Action act = () => new ShortUrl(value);

        // Assert
        act.ShouldThrow<InvalidShortUrlException>();
    }
}