
using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class AppointmentManager : Manager
    {
        public override void TrackOptions(int AppointmentOption)
        {
            switch (AppointmentOption)
            {
                case 1:
                    ScheduleAppointment();
                    break;
                default:
                    break;
            }
        }

        private void ScheduleAppointment()
        {
            Console.WriteLine("********   Adding Appointment Details   ********");

            Console.WriteLine("Enter Patient ID:");
            int PatientId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Doctor ID:");
            int DoctorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Appointment Date: ");
            DateTime AppointmentDate = DateTime.Parse(Console.ReadLine());

            context.Appointments.Add(
                new Appointment(AppointmentDate, PatientId, DoctorId));
            
            context.SaveChanges();

            Console.WriteLine("Appointment Scheduled Successfully!");
        }
    }
}
