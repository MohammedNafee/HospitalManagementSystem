
namespace HMS_Phase1.Entities
{
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled
    }
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public int PatientId { get; set; } // Foreign Key
        public Patient Patient { get; set; } // Navigation Property
    }
}
