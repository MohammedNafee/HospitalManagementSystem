
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class DoctorManager : Manager
    {
        internal override void TrackOptions(string option)
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine();
                    AddDoctor();

                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine();
                    View();

                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine();
                    UpdateDoctor(ValidateInput());

                    Console.WriteLine();    
                    break;  
                default:
                    break;
            }
        }

        private void AddDoctor()
        {
            Console.WriteLine("********   Adding Doctor Details   ********");

            Console.WriteLine();

            Console.WriteLine("Enter Doctor Name: ");
            string DoctorName = Console.ReadLine();

            Console.WriteLine("Enter Doctor Age: ");
            int DoctorAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Doctor Gender: ");
            string DoctorGender = Console.ReadLine();

            Console.WriteLine("Enter Doctor Contact Number: ");
            string DoctorContactNumber = Console.ReadLine();

            Console.WriteLine("Enter Doctor Email");
            string DoctorEmail = Console.ReadLine();

            Console.WriteLine("Enter Doctor Specialty");
            string DoctorSpecialty = Console.ReadLine();

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

            if (doctorsList == null)
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

                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine();

                    Console.WriteLine();

                    switch (input)
                    {
                        case "1":
                            Console.Write("Enter new Name: ");
                            doctor.Name = Console.ReadLine();
                            break;

                        case "2":
                            Console.Write("Enter new Age: ");
                            if (int.TryParse(Console.ReadLine(), out int newAge))
                            {
                                doctor.Age = newAge;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Age must be a number.");
                            }
                            break;

                        case "3":
                            Console.Write("Enter new Gender: ");
                            doctor.Gender = Console.ReadLine();
                            break;

                        case "4":
                            Console.Write("Enter new Contact Number: ");
                            doctor.ContactNumber = Console.ReadLine();
                            break;

                        case "5":
                            Console.Write("Enter new Email: ");
                            doctor.Email = Console.ReadLine();
                            break;

                        case "6":
                            Console.Write("Enter new Specialty: ");
                            doctor.Specialty = Console.ReadLine();
                            break;

                        case "7":
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



    }
}
