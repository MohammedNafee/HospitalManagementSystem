
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class PatientManager : Manager
    {

        public override void TrackOptions(int PatientOption)
        {
            switch (PatientOption)
            {
                case 1:
                    AddPatient();
                    break;
                default:
                    break;
            }
        }
        private void AddPatient()
        {
            Console.WriteLine("********   Adding Patient Details   ********");

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

            Console.WriteLine("Patient added Successfully!");
        }
    }
}
