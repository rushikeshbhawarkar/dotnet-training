using jul_28.Model;

namespace _28Jul.Services
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);

        Product AddProduct(Product product);

        Product UpdateProduct(int id, Product product);

        bool DeleteProduct(int id);
    }
}