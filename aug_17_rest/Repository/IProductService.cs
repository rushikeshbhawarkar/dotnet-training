using aug_17_rest.Model;

namespace aug_17_rest.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
    }
}
