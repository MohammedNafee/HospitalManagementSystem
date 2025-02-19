
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class MedicationManager : Manager
    {
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
            Console.WriteLine("********   Adding Medication Details   ********");

            string MedicationName = ValidateInputString("Medication Name: ");

            int MedicationQuantity = ValidateInput("Enter Medication Quantity: ");

            decimal MedicationPrice = ValidateInputDecimal("Enter Medication Price: ");

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
