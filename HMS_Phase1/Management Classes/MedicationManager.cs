
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class MedicationManager : Manager
    {
        public override void TrackOptions(int MedicationOption)
        {
            switch (MedicationOption)
            {
                case 1:
                    AddMedication();
                    break;
                case 2:
                    ViewMedications();
                    break;
                default:
                    break;
            }
        }

        private void AddMedication()
        {
            Console.WriteLine("********   Adding Medication Details   ********");

            Console.WriteLine("Medication Name: ");
            string MedicationName = Console.ReadLine();

            Console.WriteLine("Enter Medication Quantity: ");
            int MedicationQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Medication Price: ");
            decimal MedicationPrice = decimal.Parse(Console.ReadLine());

            context.Medications.Add(
                new Medication(MedicationName, MedicationQuantity, MedicationPrice)
                );
            
            context.SaveChanges();

            Console.WriteLine("Medication added Successfully!");
        }

        private void ViewMedications()
        {
            var medicationResult = context.Medications.ToList();

            Console.WriteLine("********   Medications List   ********");

            foreach (var medication in medicationResult)
            {
                Console.WriteLine(medication);
            }
        }
    }
}
