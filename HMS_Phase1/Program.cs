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

                Console.WriteLine("\r");

                Console.WriteLine("Enter the option number: ");

                Console.WriteLine(
                    $"1. Patient Management\r\n" +
                    $"2. Doctor Management\r\n" +
                    $"3. Appointment Management\r\n" +
                    $"4. Medication Management\r\n" +
                    $"5. Prescription Management\r\n" +
                    $"6. Billing Management\r\n" +
                    $"7. Exit"
                );

                int Option = int.Parse(Console.ReadLine());

                Console.WriteLine("\r");
                Console.WriteLine("========   Second Menu   ========");

                switch (Option)
                {
                    case 1:
                        Console.WriteLine(
                            $"1- Add Patient\r\n" +
                            $"2- View Patients\r\n" +
                            $"3- Update Patient\r\n" +
                            $"4- Delete Patient\r\n"
                        );

                        patientManager.TrackOptions(int.Parse(Console.ReadLine()));
                        break;

                    case 2:
                        Console.WriteLine(
                            $"1- Add Doctor\r\n" +
                            $"2- View Doctors\r\n" +
                            $"3- Update Doctor\r\n" +
                            $"4- Delete Doctor\r\n"
                        );
                        doctorManager.TrackOptions(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        Console.WriteLine(
                            $"1- Schedule Appointment\r\n" +
                            $"2- View Appointments\r\n" +
                            $"3- Cancel Appointment\r\n"
                        );
                        appointmentManager.TrackOptions(int.Parse(Console.ReadLine()));
                        break;

                    case 4:
                        Console.WriteLine(
                            $"1- Add Medication\r\n" +
                            $"2- View Medications\r\n"
                        );
                        medicationManager.TrackOptions(int.Parse(Console.ReadLine()));
                        break;

                    case 5:
                        Console.WriteLine(
                            $"1- Issue Prescription\r\n" +
                            $"2- View Prescriptions\r\n"
                        );
                        prescriptionManager.TrackOptions(int.Parse(Console.ReadLine()));
                        break;
                    case 6:
                        Console.WriteLine(
                            $"1- View Bills\r\n"
                        );
                        billingManager.TrackOptions(int.Parse(Console.ReadLine()));
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
