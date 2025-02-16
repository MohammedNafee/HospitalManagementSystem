
using HMS_Phase1.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HMS_Phase1.Management_Classes
{
    public class PrescriptionManager : Manager
    {
        public event EventHandler<PrescriptionEventArgs> GenerateBill;
        public override void TrackOptions(int option)
        {
            switch (option)
            {
                case 1:
                    IssuePrescription();
                    break;
                case 2:
                    ViewPrescriptions();
                    break;
                default:
                    break;
            }
        }

        private void IssuePrescription()
        {
            Console.WriteLine("********   Adding Prescription Details   ********");

            Console.WriteLine("Enter Prescription Date: ");
            DateTime PrescriptionDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Patient ID: ");
            int PatientId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Doctor ID: ");
            int DoctorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Medication ID: ");
            int MedicationId = int.Parse(Console.ReadLine());

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

        private void ViewPrescriptions()
        {
            var prescriptionResult = context.Prescriptions.ToList();

            Console.WriteLine("********   Prescriptions List   ********");

            foreach (var prescription in prescriptionResult)
            {
                Console.WriteLine(prescription);
            }
        }
    }
}
