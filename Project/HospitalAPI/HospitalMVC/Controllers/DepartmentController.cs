using HospitalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HospitalMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Department/Index
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var departments =
                await client.GetFromJsonAsync<List<Department>>(
                    "api/Department");

            return View(departments ?? new List<Department>());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var department =
                await client.GetFromJsonAsync<Department>(
                    $"api/Department/{id}");

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PostAsJsonAsync(
                "api/Department",
                department);

            if (!response.IsSuccessStatusCode)
            {
                return View(department);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var department =
                await client.GetFromJsonAsync<Department>(
                    $"api/Department/{id}");

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PutAsJsonAsync(
                $"api/Department/{id}",
                department);

            if (!response.IsSuccessStatusCode)
            {
                return View(department);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var department =
                await client.GetFromJsonAsync<Department>(
                    $"api/Department/{id}");

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.DeleteAsync(
                $"api/Department/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}