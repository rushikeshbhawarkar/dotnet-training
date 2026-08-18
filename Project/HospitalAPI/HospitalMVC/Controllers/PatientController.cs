using HospitalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HospitalMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PatientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Patient/Index
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var patients =
                await client.GetFromJsonAsync<List<Patient>>(
                    "api/Patient");

            return View(patients ?? new List<Patient>());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var patient =
                await client.GetFromJsonAsync<Patient>(
                    $"api/Patient/{id}");

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PostAsJsonAsync(
                "api/Patient",
                patient);

            if (!response.IsSuccessStatusCode)
            {
                return View(patient);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var patient =
                await client.GetFromJsonAsync<Patient>(
                    $"api/Patient/{id}");

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PutAsJsonAsync(
                $"api/Patient/{id}",
                patient);

            if (!response.IsSuccessStatusCode)
            {
                return View(patient);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var patient =
                await client.GetFromJsonAsync<Patient>(
                    $"api/Patient/{id}");

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.DeleteAsync(
                $"api/Patient/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}