using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Repositories;

public interface IUrlRepository
{
    Task<IEnumerable<Url>> GetAll();
    Task<Url> GetByOriginalUrl(string url);
    Task AddAsync(Url url);
    
    Task<Url> GetByShortUrl(string shortUrl);
}