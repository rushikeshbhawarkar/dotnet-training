namespace aug_17_mvc.Models
{
    public class OrderItems
    {
        public int Id { get; set; }

        //foreign key referencing product table
        public int ProductId { get; set; }

        //allows access to product details
        public Product? Product { get; set; }

        //foreign key referencing Order table
        public int OrderId { get; set; }

        //allow access to order 
        public Order? Order { get; set; }

        public int Quantity { get; set; }
    }
}
