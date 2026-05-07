using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Repositories
{
    public interface IPatientRepository
    {

        Task AddAsync(Patient patient);
        Task<List<Patient>> GetAllAsync();
    }
}
