using System.Security.Cryptography.Pkcs;

namespace aug_14.Models
{
    public class CutomerProduct
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
