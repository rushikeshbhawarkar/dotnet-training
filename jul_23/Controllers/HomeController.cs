using jul_23.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jul_23.Controllers
{
    public class HomeController : Controller
    {
        //GET : Login
        public IActionResult Index()
        {
            return View();
        }
        //POST Login
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Invalid user Name";
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
