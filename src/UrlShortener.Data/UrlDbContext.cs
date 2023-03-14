using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Data;

public sealed class UrlDbContext : DbContext
{
    public DbSet<Url> Urls { get; set; }

    public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}