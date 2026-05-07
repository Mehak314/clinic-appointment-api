using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClinicAppointmentSystem.Data
{
       public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Patient> Patients { get; set; }
            public DbSet<Appointment> Appointments { get; set; }
        }
    
}
