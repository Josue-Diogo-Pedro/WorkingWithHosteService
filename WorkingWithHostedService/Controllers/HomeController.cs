using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkingWithHostedService.Models;
using WorkingWithHostedService.Services;

namespace WorkingWithHostedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BackgroundServiceT teste;

        public HomeController(ILogger<HomeController> logger, BackgroundServiceT tt)
        {
            _logger = logger;
            teste = tt;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            await teste.StartAsync(token);
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