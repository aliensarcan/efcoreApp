using Microsoft.AspNetCore.Mvc;
using efcoreApp.Models;
using System.Diagnostics;

namespace efcoreApp.Controllers
{
    // Ana sayfa ve hata yönetimi için kullanılan denetleyici
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor metodu, ILogger bağımlılığını alır
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana sayfa yönlendirme metodu
        public IActionResult Index()
        {
            return View();
        }

        // Gizlilik sayfası yönlendirme metodu
        public IActionResult Privacy()
        {
            return View();
        }

        // Hata yönetimi sayfası yönlendirme metodu
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
