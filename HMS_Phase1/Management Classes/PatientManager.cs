using HMS_Phase1.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HMS_Phase1.Management_Classes
{
    public class PatientManager : Manager
    {

        public override void TrackOptions(string option)
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine();

                    AddPatient();

                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine();

                    ViewPatients();

                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine();

                    Console.WriteLine("Enter Patient ID: ");
                    int patientId = int.Parse(Console.ReadLine());
                    
                    UpdatePatient(patientId);

                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine();

                    Console.WriteLine("Enter Patient ID: ");
                    int patientID = int.Parse(Console.ReadLine());
                    
                    DeletePatient(patientID);

                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }
        private void AddPatient()
        {
            Console.WriteLine("********   Adding Patient Details   ********");

            Console.WriteLine();    

            Console.WriteLine("Enter Patient Name: ");
            string PatientName = Console.ReadLine();

            Console.WriteLine("Enter Patient Age: ");
            int PatientAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Patient Gender: ");
            string PatientGender = Console.ReadLine();

            Console.WriteLine("Enter Patient Contact Number: ");
            string PatientContactNumber = Console.ReadLine();

            Console.WriteLine("Enter Patient Address");
            string PatientAddress = Console.ReadLine();

            context.Patients.Add(
                new Patient(PatientName, PatientAge, PatientGender, PatientContactNumber, PatientAddress)
                );
            
            context.SaveChanges();

            Console.WriteLine();

            Console.WriteLine("Patient added Successfully!");
        }

        private void ViewPatients()
        {
            Console.WriteLine("********   Patients List   ********");
            Console.WriteLine();    

            var patientsList = context.Patients.ToList();

            if (patientsList == null)
            {
                Console.WriteLine("No patients available.");
                return;
            }

            foreach (var patient in patientsList)
            {
                Console.WriteLine(patient);

                Console.WriteLine();
            }

            Console.WriteLine("********   End of List   ********");
            Console.WriteLine();
        }

        private void UpdatePatient(int patientId)
        {
            Console.WriteLine("********   Update Patient   ********");

            Console.WriteLine();

            var patient = context.Patients.SingleOrDefault(p => p.PatientId == patientId);

            if (patient != null)
            {
                while (true)
                {
                    Console.WriteLine();

                    Console.WriteLine("Select the field you want to update:");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Age");
                    Console.WriteLine("3. Gender");
                    Console.WriteLine("4. Contact Number");
                    Console.WriteLine("5. Address");
                    Console.WriteLine("6. Save and Exit");

                    Console.WriteLine();

                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine();

                    Console.WriteLine();

                    switch (input)
                    {
                        case "1":
                            Console.Write("Enter new Name: ");
                            patient.Name = Console.ReadLine();
                            break;

                        case "2":
                            Console.Write("Enter new Age: ");
                            if (int.TryParse(Console.ReadLine(), out int newAge))
                            {
                                patient.Age = newAge;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Age must be a number.");
                            }
                            break;

                        case "3":
                            Console.Write("Enter new Gender: ");
                            patient.Gender = Console.ReadLine();
                            break;

                        case "4":
                            Console.Write("Enter new Contact Number: ");
                            patient.ContactNumber = Console.ReadLine();
                            break;

                        case "5":
                            Console.Write("Enter new Address: ");
                            patient.Address = Console.ReadLine();
                            break;

                        case "6":
                            context.SaveChanges();
                            Console.WriteLine("Patient details updated successfully!");
                            return; // Exit the method

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Patient not found!");
            }
        }

        private void DeletePatient(int patientId)
        {
            Console.WriteLine("********   Delete Patient   ********");

            Console.WriteLine();

            var patient = context.Patients.SingleOrDefault(p => p.PatientId == patientId);

            context.Patients.Remove(patient);

            context.SaveChanges();
            
            Console.WriteLine();

            Console.WriteLine("Patient deleted Successfully!");
        }
    }
}
