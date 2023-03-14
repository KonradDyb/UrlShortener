using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories;

namespace UrlShortener.Data.Repository;

public class UrlRepository : IUrlRepository
{
    private readonly UrlDbContext _dbContext;
    private readonly DbSet<Url> _urls;


    public UrlRepository(UrlDbContext dbContext)
    {
        _dbContext = dbContext;
        _urls = _dbContext.Urls;
    }

    public async Task<IEnumerable<Url>> GetAll()
        => await _urls.ToListAsync();

    public async Task<Url> GetByOriginalUrl(string url)
        => await _urls.SingleOrDefaultAsync(x => x.OriginalUrl == url);

    public async Task AddAsync(Url url)
    {
        await _urls.AddAsync(url);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Url> GetByShortUrl(string shortUrl)
        => await _urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);
    
}