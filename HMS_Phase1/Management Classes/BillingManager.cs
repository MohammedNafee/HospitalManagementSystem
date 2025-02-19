

namespace HMS_Phase1.Management_Classes
{
    public class BillingManager : Manager
    {

        internal override void TrackOptions(int option)
        {
            switch (option)
            {
                case 1:
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
            throw new NotImplementedException();
        }
        public void OnGenerateBill(object sender, PrescriptionEventArgs e)
        {
            Console.WriteLine("Generating bill for the issued prescription...");
            
            var medication = context.Medications.FirstOrDefault(med => med.MedicationId == e.MedicationId);

            if (medication != null)
            { 
                decimal totalAmount = medication.Price;

                context.Bills.Add(

                    new Entities.Bill(e.PrescriptionId, totalAmount, DateTime.Now, Entities.BillStatus.Unpaid)
                
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error: Medication not found!");
            }

        }

        protected override void View()
        {
            Console.WriteLine("********   Bills List   ********");
            Console.WriteLine();    

            var billsResult = context.Bills.ToList();

            if (billsResult == null)
            {
                Console.WriteLine("No bills available.");
                return;
            }

            foreach (var bill in billsResult)
            {
                Console.WriteLine(bill);

                Console.WriteLine();    
            }

            Console.WriteLine("********   End of List   ********");
            Console.WriteLine();
        }

    }
}
