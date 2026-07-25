using jul_15.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jul_15.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()//is an action method -- every url calls an action method
        {
            return View();//returns view to the browser
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
