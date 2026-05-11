using ClinicAppointmentSystem.Data;
using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentSystem.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient> GetByIdAsync(int id)
        {
            var data = await _context.Patients.Include(p => p.Visits).FirstOrDefaultAsync(patient => patient.Id == id);
            return data;
        }
        public async Task<bool> UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return false;
            _context.Patients.Remove(patient);
            return await _context.SaveChangesAsync() > 0;
        }

    }
    }
