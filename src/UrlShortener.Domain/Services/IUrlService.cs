using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Services;

public interface IUrlService
{
    Task<Url> ShortenUrl(string url, string alias);
    Task<IEnumerable<Url>> GetAll();
    Task<Url> GetByShortUrl(string shortUrl);
}