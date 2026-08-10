namespace aug_06.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        
    }
}
