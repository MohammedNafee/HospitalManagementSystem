
namespace HMS_Phase1.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int PatientId { get; set; } // Foreign Key
        public Patient Patient { get; set; } // Navigation Property

        public int DoctorId { get; set; } // Foreign Key
        public Doctor Doctor { get; set; } // Navigation Property

        public List<Medication> Medications { get; set; } = new List<Medication>();

    }
}
