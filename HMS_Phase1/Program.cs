using HMS_Phase1.Entities;
using HMS_Phase1.Management_Classes;

namespace HMS_Phase1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            PatientManager patientManager = new PatientManager();
            DoctorManager doctorManager = new DoctorManager();
            AppointmentManager appointmentManager = new AppointmentManager();
            MedicationManager medicationManager = new MedicationManager();
            PrescriptionManager prescriptionManager = new PrescriptionManager();
            BillingManager billingManager = new BillingManager();

            // Subscribe BillingManager to the event
            prescriptionManager.GenerateBill += billingManager.OnGenerateBill;

            while (true)
            {
                Console.WriteLine("========   Main Menu   ========");

                Console.WriteLine();

                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Doctor Management");
                Console.WriteLine("3. Appointment Management");
                Console.WriteLine("4. Medication Management");
                Console.WriteLine("5. Prescription Management");
                Console.WriteLine("6. Billing Management");
                Console.WriteLine("7. Exit");

                Console.WriteLine();
                Console.WriteLine("Enter your choice: ");
                string option = Console.ReadLine();

                Console.WriteLine("========   Second Menu   ========");

                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("1- Add Patient");
                        Console.WriteLine("2- View Patients");
                        Console.WriteLine("3- Update Patient");
                        Console.WriteLine("4- Delete Patient");

                        Console.WriteLine();

                        Console.WriteLine("Enter your choice: ");
                        
                        patientManager.TrackOptions(Console.ReadLine());
                        
                        break;

                    case "2":
                        Console.WriteLine("1- Add Doctor");
                        Console.WriteLine("2- View Doctors");
                        Console.WriteLine("3- Update Doctor");
                        Console.WriteLine("4- Delete Doctor");

                        Console.WriteLine();

                        Console.WriteLine("Enter your choice: ");

                        doctorManager.TrackOptions(Console.ReadLine());
                        
                        break;

                    case "3":
                        Console.WriteLine("1- Schedule Appointment");
                        Console.WriteLine("2- View Appointments");
                        Console.WriteLine("3- Cancel Appointment");

                        Console.WriteLine();

                        Console.WriteLine("Enter your choice: ");

                        appointmentManager.TrackOptions(Console.ReadLine());
                        
                        break;

                    case "4":
                        Console.WriteLine("1- Add Medication");
                        Console.WriteLine("2- View Medications");

                        Console.WriteLine();

                        Console.WriteLine("Enter your choice: ");

                        medicationManager.TrackOptions(Console.ReadLine());

                        break;

                    case "5":
                        Console.WriteLine("1- Issue Prescription");
                        Console.WriteLine("2- View Prescriptions");

                        Console.WriteLine();

                        Console.WriteLine("Enter your choice: ");

                        prescriptionManager.TrackOptions(Console.ReadLine());
                        
                        break;

                    case "6":
                        Console.WriteLine("1- View Bills");

                        Console.WriteLine();

                        Console.WriteLine("Enter your choice: ");

                        billingManager.TrackOptions(Console.ReadLine());
                        
                        break;

                    default:
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0); // Terminate the application
                        break;
                }
            }
        }
    }
}
