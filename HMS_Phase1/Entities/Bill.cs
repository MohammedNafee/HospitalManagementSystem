
namespace HMS_Phase1.Entities
{
    public enum BillStatus
    {
        Paid, 
        Unpaid
    }
    public class Bill
    {
        public int BillId { get; set; } 
        public int PrescriptionId { get; set; } // Foreign Key
        public Prescription Prescription { get; set; } // Navigation Property
        public decimal Amount { get; set; } 
        public DateTime BillDate { get; set; }  
        public BillStatus Status { get; set; }

        public Bill(int prescriptionId, decimal amount, DateTime billDate, BillStatus status)
        {
            PrescriptionId = prescriptionId;
            Amount = amount;
            BillDate = billDate;
            Status = status;
        }

        public override string ToString()
        {
            return $"Bill => ID: {BillId}, Date: {BillDate}, Total amount: {Amount}, Status: {Status}";
        }
    }
}
