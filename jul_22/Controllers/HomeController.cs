using jul_22.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jul_22.Controllers
{
    public class HomeController : Controller
    {
        //Display form
        public IActionResult Index()
        {
            return View();
        }
        //Receive Form Data
        //[HttpPost]
        //public ActionResult Index(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Normally saves to DB
        //        return Content($"Product : {product.Name}, "+$"Price : {product.Price}, "+$"Category : {product.Category}, "+$"Stock : {product.Stock}");
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(Stationary product)
        {
            if (ModelState.IsValid)
            {
                //Normally saves to DB
                return Content($"Product : {product.Name}, " + $"Price : {product.Price}, " + $"Category : {product.Category}, " + $"Brand : {product.Brand}");
            }
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
