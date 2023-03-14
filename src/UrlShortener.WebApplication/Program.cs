using Serilog;
using UrlShortener.Data;
using UrlShortener.Data.Exceptions;
using UrlShortener.Domain;

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
    
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDomain();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
return 0;