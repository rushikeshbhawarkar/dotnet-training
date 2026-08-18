using System.ComponentModel.DataAnnotations;

namespace aug_17_mvc.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is Mandatory")]
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        //one Order Can contain multiple order Items
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
