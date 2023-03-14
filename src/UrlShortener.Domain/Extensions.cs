using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Services;

namespace UrlShortener.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        return services;
    }
}