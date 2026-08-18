using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using aug_17_mvc.Models;

namespace aug_17_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("aug_17_rest");
            var products = await client.GetFromJsonAsync<List<Product>>("api/Product");

            return View(products ?? new List<Product>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var client = _httpClientFactory.CreateClient("aug_17_rest");
            var response = await client.PostAsJsonAsync("api/Product", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Unable to add Product.");
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("aug_17_rest");
            var product = await client.GetFromJsonAsync<Product>($"api/Product/{id}");

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
      
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var client = _httpClientFactory.CreateClient("aug_17_rest");
            var response = await client.PutAsJsonAsync($"api/Product/{id}", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Unable to update Product.");
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("aug_17_rest");
            var product = await client.GetFromJsonAsync<Product>($"api/Product/{id}");

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _httpClientFactory.CreateClient("aug_17_rest");
            var response = await client.DeleteAsync($"api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Unable to delete Product.");
            return View();
        }
    }
}