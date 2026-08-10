using aug_07.Model;

namespace aug_07.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
    }
}
