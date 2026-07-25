using Microsoft.AspNetCore.Mvc;
using problem_6_22_23jul.Models;
using System.Diagnostics;
using YourNamespace.Models;

namespace problem_6_22_23jul.Controllers
{
    //public class HomeController : Controller

    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}

    //public class AutomobileController : Controller
    //{
    //    public IActionResult Register()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public IActionResult Register(Automobile automobile)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            ViewBag.Message = "Registered Successfully";
    //            ViewBag.VehicleName =automobile.VehicleName;
    //            ViewBag.Brand=automobile.Brand;
    //            return View("Success");
    //        }
    //        return View("Register", automobile);
    //    }
    //    public IActionResult Success()
    //    {
    //        return View();
    //    }
    //} 

    public class AutomobileController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Automobile registered successfully!";
                ViewBag.VehicleName = automobile.VehicleName;
                ViewBag.Brand = automobile.Brand;


                return View("Success"); 
            }

      
            return View("Register", automobile);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
