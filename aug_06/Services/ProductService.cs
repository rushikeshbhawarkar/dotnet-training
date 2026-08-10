using aug_06.Data;
using aug_06.Repository;
using aug_06.Services;
using Microsoft.EntityFrameworkCore;

namespace aug_06.Services
{
    public class ProductService : IProductService//use ctrl+"." key to implement all methods of IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = context.products.Find(id);
            if(product != null)
            {
                context.products.Remove(product);
            }
            context.SaveChanges();
        }
        public Product? GetProductById(int id)
        {
            return context.products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return context.products.ToList(); //implement
        }

        public void UpdateProduct(Product product)
        {
            context.products.Update(product);
            context.SaveChanges();
        }
    }
}
