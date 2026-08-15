namespace HospitalAPI.Model
{
    public class AppointmentHistory
    {
        public int AppointmentHistoryId { get; set; }

        public string? Status { get; set; }

        public DateTime ChangedAt { get; set; }

        public string? Remarks { get; set; }

        // Foreign Key
        public int AppointmentId { get; set; }

        // Navigation Property
        public Appointment? Appointment { get; set; }
    }
}
