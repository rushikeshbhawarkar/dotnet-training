namespace aug_14.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public ICollection<CutomerProduct> CutomerProducts { get; set; } = new List<CutomerProduct>();
    }
}
