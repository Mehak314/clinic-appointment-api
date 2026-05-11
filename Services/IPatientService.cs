using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Services
{
    public interface IPatientService
    {
        Task AddPatient(Patient patient);
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<bool> Update(int id, Patient patient);
        Task<bool> DeletePatient(int id);
    }
}
