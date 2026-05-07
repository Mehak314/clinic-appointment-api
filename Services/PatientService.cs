using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repositories;

namespace ClinicAppointmentSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task AddPatient(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.Name))
                throw new Exception("Patient name required");

            await _repo.AddAsync(patient);
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _repo.GetAllAsync();
        }
    }
}
