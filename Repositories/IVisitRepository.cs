using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Repositories
{
    public interface IVisitRepository
    {
        Task AddVisit(Visit visit);
         Task<List<Visit>> GetVisits();
        Task<List<Visit>> GetVisitsByPatient(int patientId);    
    }
}
