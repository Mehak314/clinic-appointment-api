using ClinicAppointmentSystem.DTOs;

namespace ClinicAppointmentSystem.Services
{
    public interface IAIService
    {
        Task<string> AnalyzeSymptoms(string symptoms);
        Task<string> GeneratePatientSummary(int patientId);

    }

}
