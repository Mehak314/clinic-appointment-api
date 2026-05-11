using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Repositories
{
    public interface IPatientRepository
    {

        Task AddAsync(Patient patient);
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(int id);
    }
}
