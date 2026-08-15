using assignment_aug_13.Data;
using assignment_aug_13.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} was not found." });
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        [Authorize(Roles = "Admin")] // Restrict product creation to Admins
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = _productService.AddProduct(product);

            // Returns 201 Created with a Location header pointing to GetById
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.ID }, createdProduct);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ID)
            {
                return BadRequest(new { message = "ID in route does not match ID in body." });
            }

            var updatedProduct = _productService.UpdateProduct(product);
            if (updatedProduct == null)
            {
                return NotFound(new { message = $"Product with ID {id} was not found." });
            }

            return Ok(updatedProduct);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _productService.DeleteProduct(id);
            if (!isDeleted)
            {
                return NotFound(new { message = $"Product with ID {id} was not found." });
            }

            return NoContent(); // 204 No Content for successful deletion
        }
    }
}