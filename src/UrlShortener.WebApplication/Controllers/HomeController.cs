using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Services;

namespace UrlShortener.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlService _urlService;
        private static readonly List<Url> _urls = new();

        public HomeController(
            ILogger<HomeController> logger,
            IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        [Route("/{shortUrl}")]
        public async Task<IActionResult> Temp(string shortUrl)
        {
            var url = await _urlService.GetByShortUrl(shortUrl);

            if (url == null)
            {
                return NotFound();
            }

            return Redirect(url.OriginalUrl);
        }
        
        [HttpPost]
        public async Task<IActionResult> Shorten(string url, string alias)
        {
            var newUrl = await _urlService.ShortenUrl(url, alias);
        
            return View("Index", newUrl.ShortUrl.Value);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TechTaskDetails()
        {
            return View("TechTaskDetails");
        }
        public async Task<IActionResult> AllUrls()
        {
            var urls = await _urlService.GetAll();
            
            return View("AllUrls", urls);
        }
    }
}