using HMS_Phase1.Entities;

namespace HMS_Phase1.Management_Classes
{
    public class AppointmentManager : Manager
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
                    CancelAppointment(ValidateInput("Enter Appointment ID: "));

                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        protected override void Add()
        {
            Console.WriteLine("********   Adding Appointment Details   ********");

            int PatientId = ValidateInput("Enter Patient ID: ");

            int DoctorId = ValidateInput("Enter Doctor ID: ");

            DateTime AppointmentDate = ValidateInputDate("Enter Appointment Date: ");

            context.Appointments.Add(
                new Appointment(AppointmentDate, PatientId, DoctorId));
            
            context.SaveChanges();

            Console.WriteLine("Appointment Scheduled Successfully!");
        }

        protected override void View()
        {
            Console.WriteLine("********   Appointments List   ********");
            Console.WriteLine();

            var appointmentsList = context.Appointments.ToList();

            if (appointmentsList == null)
            {
                Console.WriteLine("No appointments availabe.");
                return;
            }

            foreach (var appointment in appointmentsList)
            {
                Console.WriteLine(appointment);

                Console.WriteLine();
            }

            Console.WriteLine("********   End of List   ********");
            Console.WriteLine();
        }

        private void CancelAppointment(int appointmentId)
        {
            var appointment = context.Appointments.SingleOrDefault(apt => apt.AppointmentId == appointmentId);

            if (appointment == null)
            {
                Console.WriteLine("Appointment does not exist.");
                return;
            }  

            appointment.Status = AppointmentStatus.Canceled;
            context.SaveChanges();

            Console.WriteLine($"Appointment {appointment.AppointmentId} Canceled Successfully!");

            Console.WriteLine();
        }

    }
}
