using jul_16.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace jul_16.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> student = new List<Student>()
    {
        new Student() { Id = 101, Name = "abc", Age = 20, Course = "Dotnet Framework", Gender = "Male", Qualification= "10+2", Fees = 100 },
        new Student() { Id = 102, Name = "ttc", Age = 23, Course = "JAVA Framework", Gender = "Dont know", Qualification= "10+2", Fees = 100 },
        new Student() { Id = 103, Name = "auu", Age = 22, Course = " Framework", Gender = "Female", Qualification = "10+2", Fees = 100 },
        new Student() { Id = 104, Name = "aii", Age = 21, Course = "Dotnet", Gender = "Male", Qualification = "10+2", Fees = 100 }
    }; 

            return View(student);
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
