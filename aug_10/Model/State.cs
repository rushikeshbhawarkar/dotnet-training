using System.ComponentModel.DataAnnotations;

namespace aug_10.Model
{
    public class State
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "StateName is required")]
        [StringLength(50)]
        public string? StateName { get; set; }
    }
}
