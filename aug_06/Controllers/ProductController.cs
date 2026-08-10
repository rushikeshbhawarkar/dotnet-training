using aug_06.Repository;
using aug_06.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aug_06.Controllers
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
        public IActionResult GetProduct(int id)
        {
            var product = service.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not avaliable");
            }

            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddP(Product product)
        {
            service.AddProduct(product);
            return Ok(product);
        }
        [HttpPut]
        public IActionResult UpdateP(Product product)
        {
            service.UpdateProduct(product);
            return Ok("Product updated successfully");
        }
        [HttpDelete]
        public IActionResult DeleteP(int id)
        {
            service.DeleteProduct(id);
            return Ok("Product Deleted Successfully");
        }
    }
}
