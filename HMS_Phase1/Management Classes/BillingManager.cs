

namespace HMS_Phase1.Management_Classes
{
    public class BillingManager : Manager
    {

        public override void TrackOptions(int option)
        {
            switch (option)
            {
                case 1:
                    ViewBills();
                    break;
                default:
                    break;
            }
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

        private void ViewBills()
        {
            Console.WriteLine("********   Bills List   ********");

            var BillsResult = context.Bills.ToList();

            foreach (var bill in BillsResult)
            {
                Console.WriteLine(bill);
            }
        }

    }
}
