namespace HospitalAPI.Model
{
    public class Department
    {

        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public string? Description { get; set; }

        // Relationship:
        // One Department → Many Doctors
        public ICollection<Doctor>? Doctors { get; set; }
    }
}
