using CommGate.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace CommGate.Website.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IStringLocalizer stringLocalizer;
        private readonly IConfiguration Configuration;
        public HomeController(ILogger<HomeController> logger,IConfiguration configuration, IStringLocalizer<CorrespondenceController> _stringLocalizer)
             : base(configuration)
        {
            stringLocalizer = _stringLocalizer;
            Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}