using jul_24.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jul_24.Controllers
{
    public class HomeController : Controller
    {
        //GET login
        public IActionResult Index()
        {
            return View();
        }

        //Post login
        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                if( student.Password == "123456")
                {
                    HttpContext.Session.SetString("User",student.Username);
                    return RedirectToAction("Dashboard");
                }
                ViewBag.Error = "Invalid Username or Password";
            }
            return View(student);
        }

        //Dashboard
        //public IActionResult Dashboard()
        //{
        //    var user = HttpContext.Session.GetString("User");
        //    if (string.IsNullOrEmpty(user))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.User = user;
        //    return View();
        //}



        // Dashboard
        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index");
            }

            ViewBag.User = user;

            // Sample student data
            var studentList = new List<Student>
    {
        new Student { RollNo = 101, Username = "Rushi" },
        new Student { RollNo = 102, Username = "Kartik" },
        new Student { RollNo = 103, Username = "Arman" },
        new Student { RollNo = 104, Username = user }
    };

            return View(studentList);
        }

        //Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
