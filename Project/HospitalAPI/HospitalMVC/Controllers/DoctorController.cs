using HospitalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HospitalMVC.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DoctorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Doctor/Index
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var doctors =
                await client.GetFromJsonAsync<List<Doctor>>(
                    "api/Doctor");

            return View(doctors ?? new List<Doctor>());
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var doctor =
                await client.GetFromJsonAsync<Doctor>(
                    $"api/Doctor/{id}");

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PostAsJsonAsync(
                "api/Doctor",
                doctor);

            if (!response.IsSuccessStatusCode)
            {
                return View(doctor);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var doctor =
                await client.GetFromJsonAsync<Doctor>(
                    $"api/Doctor/{id}");

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PutAsJsonAsync(
                $"api/Doctor/{id}",
                doctor);

            if (!response.IsSuccessStatusCode)
            {
                return View(doctor);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var doctor =
                await client.GetFromJsonAsync<Doctor>(
                    $"api/Doctor/{id}");

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.DeleteAsync(
                $"api/Doctor/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}