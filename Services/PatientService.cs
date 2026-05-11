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

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _repo.GetByIdAsync(id);
            if (patient == null)
                throw new Exception("Patient not found");
            return patient;
        }
        public async Task<bool> Update(int id, Patient patient)
        {
            var existingPatient = await _repo.GetByIdAsync(id);
            if (existingPatient == null)
                return false;
            existingPatient.Name = patient.Name;
            existingPatient.Age = patient.Age;
            return await _repo.UpdateAsync(existingPatient);
        }
        public async Task<bool> DeletePatient(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted)
                throw new Exception("Patient not found");
            return deleted;
        }
     
    }
    }
