using aug_14.Models;

namespace aug_14.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProductById(int id);

        Product AddProduct(Product product);

        Product UpdateProduct(Product prod);
    }
}
