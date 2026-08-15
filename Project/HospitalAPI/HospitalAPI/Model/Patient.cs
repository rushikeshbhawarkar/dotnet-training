namespace HospitalAPI.Model
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        // Relationship:
        // One Patient → Many Appointments
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
