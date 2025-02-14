
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
        public int PatientId { get; set; } // Foreign Key 
        public Patient Patient { get; set; } // Navigation Property
        
        public int PrescriptionId { get; set; } // Foreign Key
        public decimal Amount { get; set; } 
        public DateTime BillDate { get; set; }  
        public BillStatus Status { get; set; }
    }
}
