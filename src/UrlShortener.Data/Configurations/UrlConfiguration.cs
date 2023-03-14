using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.ValueObjects;

namespace UrlShortener.Data.Configurations;

internal sealed class UrlConfiguration : IEntityTypeConfiguration<Url>
{
    public void Configure(EntityTypeBuilder<Url> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UrlId(x));
        
        builder.Property(x => x.ShortUrl)
            .IsRequired()
            .HasConversion(x => x.Value, x => new ShortUrl(x));

        builder.Property(x => x.OriginalUrl)
            .IsRequired()
            .HasConversion(x => x.Value, x => new OriginalUrl(x));
    }
}