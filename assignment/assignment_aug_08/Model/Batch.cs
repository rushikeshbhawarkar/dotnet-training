using System.ComponentModel.DataAnnotations;
namespace assignment_aug_08.Model
{
    public class Batch
    {

        //[Key]
        public int BatchId { get; set; }

        public ICollection<Student>? Students { get; set; }


        [Required(ErrorMessage = "Batch name is required.")]
        [StringLength(100, ErrorMessage = "Batch name cannot exceed 100 characters.")]
        public string BatchName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}

