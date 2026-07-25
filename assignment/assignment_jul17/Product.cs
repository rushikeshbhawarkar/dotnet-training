namespace ShopEaseApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public decimal Discount { get; set; }   // stored as a percentage, e.g. 10 means 10%
        public double Rating { get; set; }      // e.g. 4.6

        public Product(int productId, string name, string category, string description,
                        decimal price, int quantity, string brand, decimal discount, double rating)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = quantity;
            Brand = brand;
            Discount = discount;
            Rating = rating;
        }

        // Final price after applying the discount percentage
        public decimal FinalPrice => Math.Round(Price - (Price * Discount / 100m), 2);

        public override string ToString()
        {
            return $"{ProductId,-6} {Name,-15} {Category,-12} {Brand,-10} " +
                   $"Rs.{Price,-10:0.00} Qty:{Quantity,-5} Disc:{Discount}% " +
                   $"FinalPrice:Rs.{FinalPrice,-10:0.00} Rating:{Rating}";
        }
    }
}
