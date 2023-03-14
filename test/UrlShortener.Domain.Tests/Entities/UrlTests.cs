using System;
using Shouldly;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.ValueObjects;
using Xunit;

namespace UrlShortener.Domain.Tests.Entities;

public class UrlTests
{
    private readonly UrlId _urlId = UrlId.Create();
    private readonly OriginalUrl _originalUrl = new("https://www.example.com");
    private readonly ShortUrl _shortUrl = new("abc12345");

    [Fact]
    public void changeurlproperties_should_change_properties_correctly()
    {
        // Arrange
        var url = new Url(_urlId, _originalUrl, _shortUrl);
        var newOriginalUrl = new OriginalUrl("https://www.example.com/new");
        var newShortUrl = new ShortUrl("def45678");

        // Act
        url.ChangeUrlProperties(newOriginalUrl, newShortUrl);

        // Assert
        url.OriginalUrl.ShouldBe(newOriginalUrl);
        url.ShortUrl.ShouldBe(newShortUrl);
    }

    [Fact]
    public void changeurlproperties_should_throw_argumentnullexception_when_originalurl_is_null()
    {
        // Arrange
        var url = new Url(_urlId, _originalUrl, _shortUrl);

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => url.ChangeUrlProperties(null, new ShortUrl("def45678")));
    }

    [Fact]
    public void changeurlproperties_should_throw_argumentnullexception_when_shorturl_is_null()
    {
        // Arrange
        var url = new Url(_urlId, _originalUrl, _shortUrl);

        // Act & Assert
        Should.Throw<ArgumentNullException>(() =>
            url.ChangeUrlProperties(new OriginalUrl("https://www.example.com/new"), null));
    }
}