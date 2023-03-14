using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Data.Exceptions;
using UrlShortener.Data.Repository;
using UrlShortener.Domain.Repositories;

namespace UrlShortener.Data;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UrlDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<IUrlRepository, UrlRepository>();
        services.AddSingleton<ExceptionMiddleware>();

        return services;
    }
}