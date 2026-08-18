using aug_17_rest.Data;
using aug_17_rest.Model;
using aug_17_rest.Repository;

namespace aug_17_rest.Services
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
    }
}
