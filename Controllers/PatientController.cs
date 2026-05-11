using Microsoft.AspNetCore.Mvc;
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Services;

namespace ClinicAppointmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        // POST: api/patient
        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            await _service.AddPatient(patient);

            return Ok("Patient added successfully");
        }

        // GET: api/patient
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients = await _service.GetPatients();

            return Ok(patients);
        }

        // GET: api/patient/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _service.GetPatientById(id);

            if (patient == null)
                return NotFound("Patient not found");

            return Ok(patient);
        }

        // PUT: api/patient/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            var updated = await _service.Update(id, patient);

            if (!updated)
                return NotFound("Patient not found");

            return Ok("Patient updated successfully");
        }

        // DELETE: api/patient/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeletePatient(id);

            if (!deleted)
                return NotFound("Patient not found");

            return Ok("Patient deleted successfully");
        }
    }
}