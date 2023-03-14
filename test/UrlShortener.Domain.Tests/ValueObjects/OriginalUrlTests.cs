using System;
using UrlShortener.Domain.Exceptions;
using UrlShortener.Domain.ValueObjects;
using Xunit;
using Shouldly;

namespace UrlShortener.Domain.Tests.ValueObjects;

public class OriginalUrlTests
{
    [Theory]
    [InlineData("http://example.com")]
    [InlineData("https://example.com")]
    [InlineData("https://www.example.com")]
    [InlineData("http://example.com/path")]
    [InlineData("http://example.com/path?query=param")]
    public void should_createoriginalurl(string value)
    {
        // Arrange & Act
        var originalUrl = new OriginalUrl(value);

        // Assert
        originalUrl.Value.ShouldBe(value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("invalid-url")]
    public void should_throw_invalidoriginalurlexception(string value)
    {
        // Arrange & Act
        Action act = () =>
        {
            var originalUrl = new OriginalUrl(value);
        };

        // Assert
        act.ShouldThrow<InvalidOriginalUrlException>();
    }
    
    [Theory]
    [InlineData("ftp://example.com")]
    public void should_throw_invalidoriginalurlschemeexception(string value)
    {
        Action act = () =>
        {
            var originalUrl = new OriginalUrl(value);
        };

        act.ShouldThrow<InvalidOriginalUrlSchemeException>();
    }
}