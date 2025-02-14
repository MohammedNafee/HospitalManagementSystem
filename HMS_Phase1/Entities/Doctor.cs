
namespace HMS_Phase1.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    }
}
