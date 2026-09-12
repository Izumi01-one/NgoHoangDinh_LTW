using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Week4_DEMO_LAB_WebMCV.Models;

namespace Week4_DEMO_LAB_WebMCV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var product = new Products();
            ViewBag.Category = product.Category;
            return View(product.getProducts());
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
