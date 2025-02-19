using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class PrescriptionManager : Manager
    {
        public event EventHandler<PrescriptionEventArgs> GenerateBill;
        internal override void TrackOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine();
                    Add();

                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    View();

                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        protected override void Add()
        {
            Console.WriteLine("********   Adding Prescription Details   ********");

            DateTime PrescriptionDate = ValidateInputDate("Enter Prescription Date: ");
            int PatientId = ValidateInput("Enter Patient ID: ");
            int DoctorId = ValidateInput("Enter Doctor ID: ");
            int MedicationId = ValidateInput("Enter Medication ID: ");

            // Check if medication exists
            var medication = context.Medications.SingleOrDefault(m => m.MedicationId == MedicationId);

            if (medication == null)
            {
                Console.WriteLine("Error: Medication not found!");
                return;
            }

            // Check if enough stock is available
            if (medication.Quantity <= 0)
            {
                Console.WriteLine("Error: Medication is out of stock!");
                return;
            }

            // Decrease medication quantity by 1
            medication.Quantity -= 1;

            // Save changes to medication quantity
            context.SaveChanges();

            var prescription = new Prescription(PrescriptionDate, PatientId, DoctorId);
            context.Prescriptions.Add(prescription);
            context.SaveChanges();

            var prescriptionMedication = new PrescriptionMedication(prescription.PrescriptionId, MedicationId);
            context.PrescriptionMedications.Add(prescriptionMedication);
            context.SaveChanges();

            Console.WriteLine("Prescription added successfully!");

            // Trigger the generate bill event
            OnGenerateBill(
                new PrescriptionEventArgs(prescription.PrescriptionId, PrescriptionDate, PatientId, DoctorId, MedicationId)
            );
        }

        private void OnGenerateBill(PrescriptionEventArgs e)
        {
            GenerateBill?.Invoke(this, e);
        }

        protected override void View()
        {
            Console.WriteLine("********   Prescriptions List   ********");
            Console.WriteLine();

            var prescriptionsResult = context.Prescriptions.ToList();

            if (!prescriptionsResult.Any())
            {
                Console.WriteLine("No prescriptions available.");
                return;
            }

            foreach (var prescription in prescriptionsResult)
            {
                Console.WriteLine(prescription);

                Console.WriteLine();
            }

            Console.WriteLine("********   End of List   ********");
            Console.WriteLine();
        }
    }
}
