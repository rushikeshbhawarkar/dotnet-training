using aug_14.Data;
using aug_14.Models;
using aug_14.Repository;

namespace aug_14.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product? GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return product;
        }
    }
}
