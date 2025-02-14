
using Microsoft.EntityFrameworkCore;

namespace HMS_Phase1.Entities
{
    [PrimaryKey(nameof(MedicationId), nameof(PrescriptionId))]
    public class PrescriptionMedication
    {
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
