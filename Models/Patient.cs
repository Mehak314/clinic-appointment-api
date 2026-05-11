namespace ClinicAppointmentSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        // Navigation Property
        public List<Visit> Visits { get; set; } = new();
    }
}
