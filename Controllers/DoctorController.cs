using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorService.GetDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var doctor = await _doctorService.GetDoctor(id);
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Doctor doctor)
        {
            await _doctorService.AddDoctor(doctor);
            return Ok("Doctor added successfully");
        }

    }
}
