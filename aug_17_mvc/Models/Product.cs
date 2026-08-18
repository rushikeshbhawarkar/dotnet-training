using System.ComponentModel.DataAnnotations;

namespace aug_17_mvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Mandatory")]
        [Range(15, 1000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is Mandatory")]
        [Range(15, 1000000)]
        public int Stock { get; set; }

        //one Product can appear in many order items 
        //EF uses this property to laod related orderitems records
        public ICollection<OrderItems>? OrderItems { get; set; }

    }
}
