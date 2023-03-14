using System.Threading.Tasks;
using Moq;
using Shouldly;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;
using UrlShortener.Domain.Services;
using UrlShortener.Domain.ValueObjects;
using Xunit;

namespace UrlShortener.Domain.Tests.Services;

public class UrlServiceTests
{
    [Fact]
    public async Task shortenurl_should_return_existing_url_if_already_shortened()
    {
        // Arrange
        var urlRepository = new Mock<IUrlRepository>();
        var existingUrl = new Url(UrlId.Create(), new OriginalUrl("http://example.com"), new ShortUrl("abc12345"));
        urlRepository.Setup(r => r.GetByOriginalUrl(existingUrl.OriginalUrl)).ReturnsAsync(existingUrl);
        var urlService = new UrlService(urlRepository.Object);

        // Act
        var result = await urlService.ShortenUrl(existingUrl.OriginalUrl, "new-alias");

        // Assert
        result.ShouldBe(existingUrl);
        urlRepository.Verify(r => r.GetByOriginalUrl(existingUrl.OriginalUrl), Times.Once);
    }
    
    [Fact]
    public async Task shortenurl_should_return_new_shortened_url_with_alias()
    {
        // Arrange
        var urlRepository = new Mock<IUrlRepository>();
        var urlService = new UrlService(urlRepository.Object);

        // Act
        var result = await urlService.ShortenUrl("http://example.com", "new-alias");

        // Assert
        result.ShouldSatisfyAllConditions(
            () => result.OriginalUrl.ShouldBe(new OriginalUrl("http://example.com")),
            () => result.ShortUrl.ShouldBe(new ShortUrl("new-alias")),
            () => urlRepository.Verify(r => r.GetByOriginalUrl("http://example.com"), Times.Once),
            () => urlRepository.Verify(r => r.AddAsync(It.IsAny<Url>()), Times.Once)
        );
    }
}