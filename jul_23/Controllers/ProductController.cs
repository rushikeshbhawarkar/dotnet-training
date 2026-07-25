using jul_23.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace jul_23.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            //check login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {

                return RedirectToAction("Login", "Home");
            }
            List<Product> products = new List<Product>();
            {
                new Product { ID = 1, Name = "Laptop", Price = 78000 };
                new Product { ID = 2, Name = "Laptop", Price = 78000 };
                
            };
            
            return View(products);
        }
    }
}
