namespace HospitalAPI.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string? Status { get; set; }

        public string? Reason { get; set; }

        //Relationships

        // Patient relationship
        // One Patient → Many Appointments
        public int PatientId { get; set; }

        public Patient? Patient { get; set; }


        // Doctor relationship
        // One Doctor → Many Appointments
        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }


        // Appointment History relationship
        // One Appointment → Many History Records
        public ICollection<AppointmentHistory>? AppointmentHistories { get; set; }

    }
}
