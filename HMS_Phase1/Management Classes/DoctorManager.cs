
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class DoctorManager : Manager
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
                    UpdateDoctor(ValidateInput("Enter doctor ID: "));

                    Console.WriteLine();    
                    break; 
                case 4:
                    Console.WriteLine();
                    DeleteDoctor(ValidateInput("Enter doctor ID: "));

                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        protected override void Add()
        {
            Console.WriteLine("********   Adding Doctor Details   ********");

            Console.WriteLine();

            string DoctorName = ValidateInputString("Enter Doctor Name: ");

            int DoctorAge = ValidateInput("Enter Doctor Age: ");

            string DoctorGender = ValidateInputString("Enter Doctor Gender: ");

            string DoctorContactNumber = ValidateInputString("Enter Doctor Contact Number: ");
            
            string DoctorEmail = ValidateInputString("Enter Doctor Email");

            string DoctorSpecialty = ValidateInputString("Enter Doctor Specialty");

            context.Doctors.Add(
                new Doctor(DoctorName, DoctorAge, DoctorGender, DoctorContactNumber, DoctorEmail, DoctorSpecialty)
                );
            
            context.SaveChanges();

            Console.WriteLine();

            Console.WriteLine("Doctor added Successfully!");
        }

        protected override void View()
        {
            Console.WriteLine("********   Doctors List   ********");
            Console.WriteLine();

            var doctorsList = context.Doctors.ToList();

            if (!doctorsList.Any())
            {
                Console.WriteLine("No doctors available.");
                return;
            }

            foreach (var doctor in doctorsList)
            {
                Console.WriteLine(doctor);
            
                Console.WriteLine();
            
            }
             
            Console.WriteLine("********   End of List   ********");
            Console.WriteLine();
        }

        private void UpdateDoctor(int doctorId)
        {
            Console.WriteLine("********   Update Doctor   ********");

            Console.WriteLine();

            var doctor = context.Doctors.SingleOrDefault(p => p.DoctorId == doctorId);

            if (doctor != null)
            {
                while (true)
                {
                    Console.WriteLine();

                    Console.WriteLine("Select the field you want to update:");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Age");
                    Console.WriteLine("3. Gender");
                    Console.WriteLine("4. Contact Number");
                    Console.WriteLine("5. Email");
                    Console.WriteLine("6. Specialty");
                    Console.WriteLine("6. Save and Exit");

                    Console.WriteLine();

                    int input = ValidateInput("Enter your choice: ");

                    Console.WriteLine();

                    switch (input)
                    {
                        case 1:
                            doctor.Name = ValidateInputString("Enter new Name: ");
                            break;
                        case 2:
                            doctor.Age = ValidateInput("Enter new Age: ");
                            break;
                        case 3:
                            doctor.Gender = ValidateInputString("Enter new Gender: ");
                            break;
                        case 4:
                            doctor.ContactNumber = ValidateInputString("Enter new Contact Number: ");
                            break;
                        case 5:
                            doctor.Email = ValidateInputString("Enter new Email: ");
                            break;
                        case 6:
                            doctor.Specialty = ValidateInputString("Enter new Specialty: ");
                            break;
                        case 7:
                            context.SaveChanges();
                            Console.WriteLine("Doctor details updated successfully!");
                            return; // Exit the method
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Doctor not found!");
            }
        }

        private void DeleteDoctor(int doctorId)
        {
            Console.WriteLine("********   Delete Doctor   ********");
            Console.WriteLine();

            var doctor = context.Doctors.SingleOrDefault(d => d.DoctorId == doctorId);

            if (doctor == null)
            {
                Console.WriteLine("Doctor Not Found!");
                return;
            }

            // Check for dependencies
            bool hasAppointments = context.Appointments.Any(a => a.DoctorId == doctorId);
            bool hasPrescriptions = context.Prescriptions.Any(p => p.DoctorId == doctorId);

            if (hasAppointments || hasPrescriptions)
            {
                Console.WriteLine("Warning: Deleting this doctor will also delete related records due to cascade delete.");
                Console.WriteLine($" - Appointments: {(hasAppointments ? "Yes" : "No")}");
                Console.WriteLine($" - Prescriptions: {(hasPrescriptions ? "Yes" : "No")}");

                string input = ValidateInputString("Are you sure you want to proceed with deletion? (yes/no)");

                if (input.ToLower() != "yes")
                {
                    Console.WriteLine("Deletion canceled.");
                    return;
                }
            }

            // Proceed with deletion
            context.Doctors.Remove(doctor);
            context.SaveChanges();

            Console.WriteLine("Doctor deleted successfully, along with related records.");
        }


    }
}
