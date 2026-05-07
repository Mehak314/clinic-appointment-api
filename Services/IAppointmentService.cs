using ClinicAppointmentSystem.DTOs;
using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Services
{
    public interface IAppointmentService
    {
        Task BookAppointment(BookAppointmentDto appointment);
    }
}
