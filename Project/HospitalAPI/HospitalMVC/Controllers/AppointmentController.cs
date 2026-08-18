using HospitalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HospitalMVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Appointment/Index
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var appointments =
                await client.GetFromJsonAsync<List<Appointment>>(
                    "api/Appointment");

            return View(appointments ?? new List<Appointment>());
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var appointment =
                await client.GetFromJsonAsync<Appointment>(
                    $"api/Appointment/{id}");

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PostAsJsonAsync(
                "api/Appointment",
                appointment);

            if (!response.IsSuccessStatusCode)
            {
                return View(appointment);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var appointment =
                await client.GetFromJsonAsync<Appointment>(
                    $"api/Appointment/{id}");

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PutAsJsonAsync(
                $"api/Appointment/{id}",
                appointment);

            if (!response.IsSuccessStatusCode)
            {
                return View(appointment);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var appointment =
                await client.GetFromJsonAsync<Appointment>(
                    $"api/Appointment/{id}");

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.DeleteAsync(
                $"api/Appointment/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}