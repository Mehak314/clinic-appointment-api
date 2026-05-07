using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repositories;
namespace ClinicAppointmentSystem.Services
{
  

    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;

        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doctor = await _repo.GetByIdAsync(id);

            if (doctor == null)
                throw new Exception("Doctor not found");

            return doctor;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            // 🔥 Business validation
            if (string.IsNullOrEmpty(doctor.Name))
                throw new Exception("Doctor name is required");

            await _repo.AddAsync(doctor);
        }
    }
}
