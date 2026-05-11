using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Services
{
    public interface IVisitService
    {

        Task AddVisit(Visit visit);

        Task<List<Visit>> GetVisits();

        Task<List<Visit>> GetVisitsByPatient(int patientId);

    }
}
