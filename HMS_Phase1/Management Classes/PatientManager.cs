using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class PatientManager : Manager
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
                case 3:
                    Console.WriteLine();
                    UpdatePatient(ValidateInput("Enter Patient ID: "));

                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine();
                    DeletePatient(ValidateInput("Enter Patient ID: "));

                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }
        protected override void Add()
        {
            Console.WriteLine("********   Adding Patient Details   ********");

            Console.WriteLine();    

            string PatientName = ValidateInputString("Enter Patient Name: ");

            int PatientAge = ValidateInput("Enter Patient Age: ");

            string PatientGender = ValidateInputString("Enter Patient Gender: ");

            string PatientContactNumber = ValidateInputString("Enter Patient Contact Number: ");
            
            string PatientAddress = ValidateInputString("Enter Patient Address");

            context.Patients.Add(
                new Patient(PatientName, PatientAge, PatientGender, PatientContactNumber, PatientAddress)
                );
            
            context.SaveChanges();

            Console.WriteLine();

            Console.WriteLine("Patient added Successfully!");
        }

        protected override void View()
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

                    int input = ValidateInput("Enter your choice: ");

                    Console.WriteLine();

                    switch (input)
                    {
                        case 1:
                            patient.Name = ValidateInputString("Enter new Name: ");
                            break;
                        case 2:
                            patient.Age = ValidateInput("Enter new Age: ");
                            break;
                        case 3:
                            patient.Gender = ValidateInputString("Enter new Gender: ");
                            break;
                        case 4:
                            patient.ContactNumber = ValidateInputString("Enter new Contact Number: ");
                            break;
                        case 5:
                            patient.Address = ValidateInputString("Enter new Address: ");
                            break;
                        case 6:
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

            if (patient == null)
            {
                Console.WriteLine("Patient Not Found!");
                return;
            }

            // Check for dependencies
            bool hasAppointments = context.Appointments.Any(a => a.PatientId == patientId);
            bool hasPrescriptions = context.Prescriptions.Any(p => p.PatientId == patientId);
            bool hasBills = context.Bills.Any(b => b.Prescription.PatientId == patientId);

            if (hasAppointments || hasPrescriptions || hasBills)
            {
                Console.WriteLine("Warning: Deleting this patient will also delete related records due to cascade delete.");
                Console.WriteLine($" - Appointments: {(hasAppointments ? "Yes" : "No")}");
                Console.WriteLine($" - Prescriptions: {(hasPrescriptions ? "Yes" : "No")}");
                Console.WriteLine($" - Bills: {(hasBills ? "Yes" : "No")}");

                string input = ValidateInputString("Are you sure you want to proceed with deletion? (yes/no)");
                
                if (input.ToLower() != "yes")
                {
                    Console.WriteLine("Deletion canceled.");
                    return;
                }
            }

            // Proceed with deletion
            context.Patients.Remove(patient);
            context.SaveChanges();

            Console.WriteLine("Patient deleted successfully, along with related records.");
        }

    }
}
