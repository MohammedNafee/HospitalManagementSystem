
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class DoctorManager : Manager
    {
        public override void TrackOptions(string option)
        {
            switch (option)
            {
                case "1":
                    AddDoctor();
                    break;
                case "2":
                    ViewDoctors(); 
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

        private void ViewDoctors()
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
    }
}
