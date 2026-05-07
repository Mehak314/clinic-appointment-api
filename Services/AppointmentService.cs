using ClinicAppointmentSystem.DTOs;
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repositories;
namespace ClinicAppointmentSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task BookAppointment(BookAppointmentDto bookAppointment)
        {
            // 🔥 Validation 1: Time check
            if (bookAppointment.StartTime >= bookAppointment.EndTime)
                throw new Exception("Invalid time range");

            // 🔥 Validation 2: Doctor availability
            var isAvailable = await _repo.IsDoctorAvailable(
                bookAppointment.DoctorId,
                bookAppointment.StartTime,
                bookAppointment.EndTime
            );

            if (!isAvailable)
                throw new Exception("Doctor is not available at this time");

            var appointment = new Appointment
            {
                DoctorId = bookAppointment.DoctorId,
                PatientId = bookAppointment.PatientId,
                StartTime = bookAppointment.StartTime,
                EndTime = bookAppointment.EndTime,
                Status = "Booked"
            };

            await _repo.AddAsync(appointment);
        }
    }
}
