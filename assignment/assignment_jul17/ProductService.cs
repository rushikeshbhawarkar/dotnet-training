using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1001;

        public ProductService()
        {
            // Seed with the example product from the spec
            AddProduct("Laptop", "Electronics", "Dell Inspiron", 65000m, 20, "Dell", 10m, 4.6);
        }

        // ---------------- Add Product ----------------
        public Product AddProduct(string name, string category, string description, decimal price,
                                   int quantity, string brand, decimal discount, double rating)
        {
            var product = new Product(_nextId++, name, category, description, price, quantity, brand, discount, rating);
            _products.Add(product);
            return product;
        }

        // ---------------- Update Product ----------------
        public (bool Success, string Message) UpdateProduct(int productId, string name, string category,
            string description, decimal price, int quantity, string brand, decimal discount, double rating)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
                return (false, $"Product with ID {productId} not found.");

            product.Name = name;
            product.Category = category;
            product.Description = description;
            product.Price = price;
            product.Quantity = quantity;
            product.Brand = brand;
            product.Discount = discount;
            product.Rating = rating;

            return (true, "Product updated successfully.");
        }

        // ---------------- Delete Product ----------------
        public (bool Success, string Message) DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
                return (false, $"Product with ID {productId} not found.");

            _products.Remove(product);
            return (true, "Product deleted successfully.");
        }

        // ---------------- Search Product ----------------
        public List<Product> SearchProduct(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Product>();

            return _products.Where(p =>
                p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                p.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                p.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                p.ProductId.ToString() == keyword
            ).ToList();
        }

        // ---------------- View All Products ----------------
        public List<Product> GetAllProducts()
        {
            return _products.ToList();
        }

        public Product? GetById(int productId)
        {
            return _products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
