using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;
using UrlShortener.Domain.ValueObjects;

namespace UrlShortener.Domain.Services;

public class UrlService : IUrlService
{
    private readonly IUrlRepository _urlRepository;

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<Url> ShortenUrl(string url, string alias)
    {
        var existingUrl = await _urlRepository.GetByOriginalUrl(url);
        
        if (existingUrl != null)
        {
            return existingUrl;
        }
        
        var newUrl = string.IsNullOrWhiteSpace(alias) ? new Url(UrlId.Create(), new OriginalUrl(url), GenerateShortUrl()) : new Url(UrlId.Create(), new OriginalUrl(url), new ShortUrl(alias));

        await _urlRepository.AddAsync(newUrl);
        return newUrl;
    }

    public async Task<IEnumerable<Url>> GetAll()
    {
        return await _urlRepository.GetAll();
    } 
    public async Task<Url> GetByShortUrl(string shortUrl)
    {
        return await _urlRepository.GetByShortUrl(shortUrl);
    }

    private string GenerateShortUrl()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return result;
    }
}