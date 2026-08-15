using aug_14.Models;
using aug_14.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aug_14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = service.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetProduct(int id)
        {
            var product = service.GetProductById(id);
            if (product == null)
            {
                return NotFound("The Product not Found");
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddProduct( Product product)
        {
            service.AddProduct(product);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
             service.UpdateProduct(product);
            return Ok();
        }
    }
}
