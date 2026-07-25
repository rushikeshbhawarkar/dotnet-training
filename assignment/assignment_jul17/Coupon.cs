namespace ShopEaseApp.Models
{
    public class Coupon
    {
        public string Code { get; set; }
        public decimal DiscountPercent { get; set; }

        public Coupon(string code, decimal discountPercent)
        {
            Code = code;
            DiscountPercent = discountPercent;
        }
    }
}
