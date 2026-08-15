using Microsoft.EntityFrameworkCore;
using assignment_aug_13.Data;
namespace assignment_aug_13.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;
        public ProductService(AppDbContext _context)
        {
            context = _context;
        }
        public Product AddProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return true;
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            var product_1 = context.Products.Find(id);
            return product_1;
        }

        public Product? UpdateProduct(Product product)
        {
            var existingProduct = context.Products.Find(product.ID);
            if (existingProduct == null)
            {
                return null;
            }

            // Update individual properties
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            context.SaveChanges();

            return existingProduct;
        }
    }
}
