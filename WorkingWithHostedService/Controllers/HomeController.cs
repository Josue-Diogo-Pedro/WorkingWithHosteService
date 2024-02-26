using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkingWithHostedService.Models;
using WorkingWithHostedService.Services;

namespace WorkingWithHostedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SettingService _settingService;

        public HomeController(ILogger<HomeController> logger, SettingService settingService)
        {
            _logger = logger;
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            _settingService.IsEnabled = false;
            return View();
        }

        public IActionResult Privacy()
        {
            _settingService.IsEnabled = true;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}