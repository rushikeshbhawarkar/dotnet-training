using System.ComponentModel.DataAnnotations;

namespace assignment_06.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order name is mandatory")]
        [StringLength(100, ErrorMessage = "Order name can be max 100 letters")]
        public string? OrderName { get; set; }

        [Required(ErrorMessage = "Order Quantity is mandatory")]
        [Range(1, 500, ErrorMessage = "Order quantity must be between 1 and 500")]
        public int OrderQuantity { get; set; }

        [Required(ErrorMessage = "Total price is mandatory")]
        [Range(1, 1000000, ErrorMessage = "Total price cannot be less than 1 & more than 1000000")]
        public decimal TotalPrice { get; set; } 
    }
}