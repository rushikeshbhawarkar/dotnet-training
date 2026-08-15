namespace HospitalAPI.Model
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string? Name { get; set; }

        public string? Specialization { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        //------------------------
        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department? Department { get; set; }

        // One Doctor → Many Appointments
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
