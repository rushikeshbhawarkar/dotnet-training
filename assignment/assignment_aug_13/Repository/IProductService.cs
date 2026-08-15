using assignment_aug_13;

namespace assignment_aug_13
{
    public interface IProductService
    {
        // Customer Operations
        List<Product> GetAllProducts();
        Product? GetProductById(int id);

        // Admin Operations
        Product AddProduct(Product product);
        Product? UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}