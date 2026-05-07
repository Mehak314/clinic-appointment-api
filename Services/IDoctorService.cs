using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Services
{
    public interface IDoctorService
    {

        Task<List<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task AddDoctor(Doctor doctor);


    }
}
