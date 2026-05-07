using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Services
{
    public interface IPatientService
    {
        Task AddPatient(Patient patient);
        Task<List<Patient>> GetPatients();
    }
}
