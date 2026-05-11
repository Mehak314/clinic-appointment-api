using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repositories;
using System;

namespace ClinicAppointmentSystem.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _repo;

        public VisitService(IVisitRepository repo)
        {
            _repo = repo;
        }

        public async Task AddVisit(Visit visit)
        {
            visit.VisitDate = DateTime.UtcNow;

            await _repo.AddVisit(visit);

        }

        public async Task<List<Visit>> GetVisits()
        {
            return await _repo.GetVisits();
        }

        public async Task<List<Visit>> GetVisitsByPatient(int patientId)
        {
            var visits = await _repo.GetVisitsByPatient(patientId);
            return visits;
        }
    }
}
