
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class MedicationManager : Manager
    {
        internal override void TrackOptions(string option)
        {
            switch (option)
            {
                case "1":
                    AddMedication();
                    break;
                case "2":
                    View();
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

        protected override void View()
        {
            Console.WriteLine("********   Medications List   ********");
            Console.WriteLine();

            var medicationsResult = context.Medications.ToList();

            if (medicationsResult == null)
            {
                Console.WriteLine("No medications available.");
                return;
            }


            foreach (var medication in medicationsResult)
            {
                Console.WriteLine(medication);

                Console.WriteLine(); 
            }

            Console.WriteLine("********   End of List   ********");
            Console.WriteLine();
        }
    }
}
