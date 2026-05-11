using ClinicAppointmentSystem.Data;
using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicAppointmentSystem.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVisit(Visit visit)
        {
            visit.VisitDate = DateTime.UtcNow;

            _context.Add(visit);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Visit>> GetVisits()
        {
            var list = await _context.Visits.Include(v => v.Patient)
                .OrderByDescending(v => v.VisitDate)
                .ToListAsync();
            return list;
        }

        public async Task<List<Visit>> GetVisitsByPatient(int patientId)
        {
            var visits = await _context.Visits
                .Where(v => v.PatientId == patientId)
                .OrderByDescending(v => v.VisitDate)
                .ToListAsync();
            return visits;
        }
    }

}
