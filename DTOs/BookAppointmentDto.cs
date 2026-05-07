namespace ClinicAppointmentSystem.DTOs
{
    public class BookAppointmentDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
