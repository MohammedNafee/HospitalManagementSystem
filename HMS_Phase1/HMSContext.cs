using Microsoft.EntityFrameworkCore;
using HMS_Phase1.Entities;

namespace HMS_Phase1
{
    public class HMSContext : DbContext 
    {
        public DbSet<Patient> Patients {  get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Bill> Bills { get; set; }  

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7E8QNOQ;Initial Catalog=HMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // A patient can have many appointments.
            modelBuilder.Entity<Appointment>()
                .HasOne(p => p.Patient)
                .WithMany(x => x.Appointments)
                .HasForeignKey(f => f.PatientId);

            // A patient can have many prescriptions.
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(x =>x.Prescriptions)
                .HasForeignKey(f => f.PatientId);

            // A patient can have many bills.
            modelBuilder.Entity<Bill>()
                .HasOne(p => p.Patient)
                .WithMany(x => x.Bills)
                .HasForeignKey(f => f.PatientId);
        }
    }
}
