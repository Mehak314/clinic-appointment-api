namespace ClinicAppointmentSystem.Models
{
    public class Visit
    {
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        public string Symptoms { get; set; } = string.Empty;

        public string? Diagnosis { get; set; }

        public DateTime VisitDate { get; set; }

        // Navigation Property
        public Patient? Patient { get; set; }
    }
}